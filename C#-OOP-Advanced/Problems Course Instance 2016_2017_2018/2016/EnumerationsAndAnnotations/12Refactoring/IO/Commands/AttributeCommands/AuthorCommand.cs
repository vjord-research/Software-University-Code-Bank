namespace _12Refactoring.IO.Commands.AttributeCommands
{
    using Attributes;
    using Factories.WeaponFactory.Weapons;

    public class AuthorCommand : Command
    {
        public override void Execute()
        {
            var attributes = typeof(Weapon).GetCustomAttributes(false);

            foreach (ClassInfoAttribute info in attributes)
            {
                OutputWriter.WriteMessageOnNewLine($"Author: {info.Author}");
            }
        }
    }
}
