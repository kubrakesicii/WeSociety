using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Commands.ReadingList.Create
{
    public class CreateReadingListCommand : ICommand<Response>
    {
        public int UserProfileId { get; set; }  //Auht userdan alınacak
        public string Name { get; set; }
    }
}
