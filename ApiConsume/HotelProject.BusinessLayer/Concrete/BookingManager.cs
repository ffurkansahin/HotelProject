﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDAL _bookingDAL;

        public BookingManager(IBookingDAL bookingDAL)
        {
            _bookingDAL = bookingDAL;
        }

        public void TBookingStatusChangeApproved(Booking booking)
        {
            _bookingDAL.BookingStatusChangeApproved(booking);
        }

        public void TChangeBookingStatusToApproved(int id)
        {
            _bookingDAL.ChangeBookingStatusToApproved(id);
        }

        public void TChangeBookingStatusToCall(int id)
        {
            _bookingDAL.ChangeBookingStatusToCall(id);
        }

        public void TChangeBookingStatusToCanceled(int id)
        {
            _bookingDAL.ChangeBookingStatusToCanceled(id);
        }

        public void TDelete(Booking t)
        {
            _bookingDAL.Delete(t);
        }

        public int TGetBookingCount()
        {
            return _bookingDAL.GetBookingCount();
        }

        public Booking TGetByID(int id)
        {
            return _bookingDAL.GetByID(id);
        }

        public List<Booking> TGetLast6Booking()
        {
            return _bookingDAL.GetLast6Booking();
        }

        public List<Booking> TGetList()
        {
            return _bookingDAL.GetList();
        }

        public void TInsert(Booking t)
        {
            _bookingDAL.Insert(t);
        }

        public void TUpdate(Booking t)
        {
            _bookingDAL.Update(t);
        }
    }
}
