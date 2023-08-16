using AutoMapper.Configuration.Conventions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Common
{
    public interface BaseCommand : IRequest
    {
        public int Id { get; set; }
    }
}
