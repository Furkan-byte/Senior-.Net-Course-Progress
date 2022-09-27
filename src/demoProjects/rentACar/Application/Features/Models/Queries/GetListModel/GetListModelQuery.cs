using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetListModel
{
    public class GetListModelQuery : IRequest<ModelListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, ModelListModel>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
            {
                //Car Model
                IPaginate<Model> models = await _modelRepository.GetListAsync(include: a => a.Include(b => b.Brand),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                //Data Model
                ModelListModel mappedModels = _mapper.Map<ModelListModel>(models);

                return mappedModels;
                    
            }
        }

    }
}
