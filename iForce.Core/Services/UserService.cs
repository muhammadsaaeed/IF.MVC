using AutoMapper;
using iForce.Core.Models;
using iForce.Core.Repositories;
using iForce.Data.Entities;
using iForce.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace iForce.Core.Services
{
    public class UserService
    {
        int maxRows = 20;

        private IRepository<User> userRepository;

        public UserService()
            :this(new UserDbRepository())
        {
        }

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserListModel GetUserListingModel(int currentPage, string sortBy = "ID", string sortOrder = "ASC")
        {
            UserListModel userListModel = new UserListModel();
            List<User> usersList = userRepository.GetList(maxRows, currentPage, sortBy, sortOrder);

            userListModel.UserList = Mapper.Map<IEnumerable<UserViewModel>>(usersList);

            userListModel.Pagination.TotalRecords = userRepository.TotalRecords();
            userListModel.Pagination.PageCount = getPageCount(userListModel.Pagination, maxRows); 
            userListModel.Pagination.CurrentPageIndex = currentPage;
            userListModel.Pagination.SortBy = sortBy;
            userListModel.Pagination.SortOrder = sortOrder;

            return userListModel;
        }

        private int getPageCount(Pagination pagination, int maxRows)
        {
            double pageCount = (double)((decimal)pagination.TotalRecords / Convert.ToDecimal(maxRows));
            return (int)Math.Ceiling(pageCount);
        }

        public UserViewModel GetUserById(int id)
        {
            return Mapper.Map<UserViewModel>(userRepository.GetById(id));
        }

        public void AddUser(UserViewModel userViewModel)
        {
            User user = Mapper.Map<User>(userViewModel);
            user.UserRoleId = userViewModel.UserRoleId;
            user.UserStatusId = userViewModel.UserStatusId;
            user.UpdateAt = DateTime.Now;
            userRepository.Add(user);
        }

        public void UpdateUser(UserViewModel userViewModel)
        {
            User user = Mapper.Map<User>(userViewModel);
            user.UserRoleId = userViewModel.UserRoleId;
            user.UserStatusId = userViewModel.UserStatusId;
            user.UpdateAt = DateTime.Now;
            userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            userRepository.DeleteById(id);
        }
    }
}
