namespace Ongkon.Contracts.Commands;

public class CreateWhiteBoardCommand : CommandBase
{
    public string Title { get; set; }
    public string UserName { get; set; }
}