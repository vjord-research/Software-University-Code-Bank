namespace GameStore.App.Infrastructure
{
    using Models.Games;
    using Models.Home;
    using Models.Orders;

    public static class HtmlHelpers
    {
        public static string ToHtml(this GameListingAdminModel game)
            => $@"
                <tr>
                    <th scope=""row"">{game.Id}</th>
                    <td>{game.Name}</td>
                    <td>{game.Size:f1} GB</td>
                    <td>{game.Price:f2} &euro;</td>
                    <td>
                        <a href=""/admin/edit?id={game.Id}"" class=""btn btn-warning btn-sm"">Edit</a>
                        <a href=""/admin/delete?id={game.Id}"" class=""btn btn-danger btn-sm"">Delete</a>
                    </td>
                </tr>";

        public static string ToHtml(this GameListingHomeModel game, bool isAdmin)
            => $@"
                <div class=""card col-4 thumbnail"">
                    <img class=""card-image-top img-fluid img-thumbnail""
                        onerror=""this.src='https://i.ytimg.com/vi/{game.VideoId}/maxresdefault.jpg';""
                        src=""{game.ThumbnailUrl}"">
                    <div class=""card-body"">
                        <h4 class=""card-title"">{game.Title}</h4>
                        <p class=""card-text""><strong>Price</strong> - {game.Price:F2}&euro;</p>
                        <p class=""card-text""><strong>Size</strong> - {game.Size:F1} GB</p>
                        <p class=""card-text"">{(game.Description.Length > 300
                                                ? game.Description.Substring(0, 300)
                                                : game.Description)}</p>
                    </div>
                    <div class=""card-footer"">
                        {(!isAdmin ? string.Empty : $@"
                            <a class=""card-button btn btn-warning"" name=""edit"" href=""/admin/edit?id={game.Id}"">Edit</a>
                            <a class=""card-button btn btn-danger"" name=""delete"" href=""/admin/delete?id={game.Id}"">Delete</a>
                        ")}
                        <a class=""card-button btn btn-outline-primary"" name=""info"" href=""/games/details?id={game.Id}"">Info</a>
                        <a class=""card-button btn btn-primary"" name=""buy"" href=""/orders/buy?id={game.Id}"">Buy</a>
                    </div>
                </div>";

        public static string ToHtml(this GameListingOrdersModel game)
            => $@"
                <div class=""list-group-item"">
                    <div class=""media"">
                        <a class=""btn btn-outline-danger btn-lg align-self-center mr-3"" href=""/orders/remove?id={game.Id}"">X</a>
                        <img class=""d-flex mr-4 align-self-center img-thumbnail"" height=""127"" src=""{game.ThumbnailUrl}"" onerror=""https://i.ytimg.com/vi/{game.VideoId}/maxresdefault.jpg""
                                width=""227"" alt=""{game.Title}"">
                        <div class=""media-body align-self-center"">
                            <a href=""/games/details?id={game.Id}"">
                                <h4 class=""mb-1 list-group-item-heading"">{game.Title}</h4>
                            </a>
                            <p>
                                {(game.Description.Length > 20
                                ? game.Description.Substring(0, 20)
                                : game.Description)}
                            </p>
                        </div>
                        <div class=""col-md-2 text-center align-self-center mr-auto"">
                            <h2>{game.Price}&euro;</h2>
                        </div>
                    </div>
                </div>";
    }
}
