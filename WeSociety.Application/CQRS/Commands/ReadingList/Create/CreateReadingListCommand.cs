using MediatR;
using WeSociety.Application.CQRS.BaseModels;

namespace WeSociety.Application.CQRS.Commands.ReadingList.Create
{
    public class CreateReadingListCommand : ICommand<Unit>
    {
        public int UserProfileId { get; set; }  //Auht userdan alınacak
        public string Name { get; set; }
    }
}
