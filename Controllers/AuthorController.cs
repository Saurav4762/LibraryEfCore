using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using 
namespace EfCoreDbContext.Controllers;

public class AuthorController
{
    private readonly EfCoreDbContext _context;

    public AuthorController(EfCoreDbContext context)
    {
        _context = context;
    }
}