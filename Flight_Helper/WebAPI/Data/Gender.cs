﻿using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }

    }
}
