using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
using ShopOnline.Model.SlideModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.ImplementationAPI
{
    public class SlideSerVice : ISlideSerVice
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public SlideSerVice(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<int> CreatSlide(CreatSlide request)
        {
            if (request.Id > 0)
            {
                var slideUpdate = await _context.Slides.FindAsync(request.Id);
                slideUpdate.Name = request.Name;

                slideUpdate.Decripstion = request.Decripstion;
                slideUpdate.PathImage = request.PathImage;
                slideUpdate.Caption = request.Caption;
                slideUpdate.ParentId = null;
                _context.Slides.Update(slideUpdate);
                
            }
            else
            {
                var slideCreat = new Slide()
                {
                    Caption = request.Caption,
                    ParentId = null,
                    Decripstion = request.Decripstion,
                    PathImage = request.PathImage,
                    Name = request.Name
                };
                _context.Slides.Add(slideCreat);

            }
            return await _context.SaveChangesAsync();
        }

        public async Task<List<SlideViewModel>> GetAllSlide()
        {
            var listslide = await _context.Slides.ToListAsync();
            var listslideViewModel = _mapper.Map<List<Slide>, List<SlideViewModel>>(listslide);
            return listslideViewModel;
        }
    }
}
