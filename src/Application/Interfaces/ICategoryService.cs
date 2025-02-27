using FlowBiz.Application.Models;
using FlowBiz.Application.ViewModels;
using FlowBiz.Domain.Entities;

namespace FlowBiz.Application.Interfaces;
public interface ICategoryService : ICRUDService<Category, CategoryCreateModel, CategoryViewModel> {}