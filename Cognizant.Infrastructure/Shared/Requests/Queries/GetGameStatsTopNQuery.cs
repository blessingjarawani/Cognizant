﻿using Cognizant.DAL.Dto;
using Cognizant.Infrastructure.Shared.Responses.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Infrastructure.Shared.Requests.Queries
{
    public class GetGameStatsTopNQuery : IRequest<IResponse<IEnumerable<GameStatsTopNDTO>>>
    {
        public int TopN { get; set; }
    }
}
