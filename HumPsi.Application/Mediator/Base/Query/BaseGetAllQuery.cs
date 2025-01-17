using AutoMapper;
using HumPsi.Application.Abstraction.IService;
using HumPsi.Domain.Abstraction.IRepositories;
using MediatR;

namespace HumPsi.Application.Mediator.Base.Query;

public abstract record BaseGetAllQuery<T>(Guid? id = null, string? title = null) : IRequest<IEnumerable<T>> where T : class;
