﻿
                    
      
    
 
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using Repository.Pattern.Repositories;

using WebApp.Models;

namespace WebApp.Repositories
{
  public static class MenuItemRepository  
    {
 
                 public static IEnumerable<MenuItem> GetByParentId(this IRepositoryAsync<MenuItem> repository, int parentid)
         {
             var query= repository
                .Queryable()
                .Where(x => x.ParentId==parentid);
             return query;

         }
             
        
                public static IEnumerable<MenuItem>   GetSubMenusByParentId (this IRepositoryAsync<MenuItem> repository,int parentid)
        {
			var menuitemRepository = repository.GetRepository<MenuItem>(); 
            return menuitemRepository.Queryable().Include(x => x.Parent).Where(n => n.ParentId == parentid);
        }
         
	}
}



