namespace Redbet.Domain.Models.Customer.Commands
{
    public class AddCustomerCommand : BaseCustomerCommand
    {
        public AddCustomerCommand(string firstName, string lastName, string address, string favoriteFootballTeam)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            FavoriteFootballTeam = favoriteFootballTeam;
        }
    }
}
