﻿using Microsoft.AspNetCore.Http;

namespace NarkoCenter.Domain.Dtos.HospitalNews
{
    public class HospitalNewsCreateDto
    {
        public string Description { get; set; }
        public IFormFile ImagePath { get; set; }
    }
}