﻿using DevTools.ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.ADO.Repositories.Comments
{
    /// <summary>
    /// This class describe all methods that will be manage in comment repository
    /// </summary>
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        /// <summary>
        /// This method get all comments concerned by the contact in parameter
        /// </summary>
        /// <param name="contactId">Represent the id of the contact</param>
        /// <returns></returns>
        ICollection<Comment> GetAllComments();

        IEnumerable<Comment> GetAllComments();
        Comment GetCommentById(int id);
        void Add(Comment entity);
        void UpdateComment(Comment comment);
        void DeleteComment(int id);

    }
}
