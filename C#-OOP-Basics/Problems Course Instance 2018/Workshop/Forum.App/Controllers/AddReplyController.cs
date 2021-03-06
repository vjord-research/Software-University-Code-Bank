using System.Linq;
using Forum.App.UserInterface.Input;
using Forum.App.UserInterface.ViewModels;
using Forum.App.Views;

namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;
    using ForumSystem.Services;

    public class AddReplyController : IController
    {
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 6;
        private const int POST_MAX_LENGTH = 220;
        private const int TOP_OFFSET = 7;

        private static int centerLeft = Position.ConsoleCenter().Left;

        private static int centerTop = Position.ConsoleCenter().Top;

        private PostViewModel post;

        public bool Error { get; private set; }

        public int PostId { get; private set; }

        public TextArea TextArea { get; private set; }

        private ReplyViewModel Reply { get; set; }

        private int TextAreaTopOffset => centerTop - (TOP_OFFSET - this.post.Content.Count) + 1;

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Write:
                    TextArea.Write();
                    Reply.Content = this.TextArea.Lines.ToList();
                    return MenuState.AddReply;
                case Command.Submit:
                    var validReply = PostService.TryAddReply(this.post.PostId, this.Reply);
                    if (!validReply)
                    {
                        Error = true;
                        return MenuState.Rerender;
                    }
                    return MenuState.ReplyAdded;
                case Command.Back:
                    return MenuState.Back;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            return new AddReplyView(post, Reply, TextArea, Error);
        }

        public void ResetReply()
        {
            TextArea = new TextArea(
                centerLeft - 18,
                TextAreaTopOffset,
                TEXT_AREA_WIDTH,
                TEXT_AREA_HEIGHT,
                POST_MAX_LENGTH);
            Reply = new ReplyViewModel();
            Error = false;
        }

        public void SetReplyToPost(int postId, string username)
        {
            PostId = postId;
            post = PostService.GetPostViewModel(postId);

            ResetReply();
            Reply.Author = username;
        }

        private enum Command
        {
            Write,
            Submit,
            Back
        }
    }
}