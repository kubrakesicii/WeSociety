﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Commands.ReadingListArticle.Delete
{
    public class DeleteReadingListArticleCommand : ICommand<Response>
    {
        public int Id { get; set; }
    }
}