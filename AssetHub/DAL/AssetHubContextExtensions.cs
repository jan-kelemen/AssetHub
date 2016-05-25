﻿using AssetHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetHub.DAL
{
    public static class AssetHubContextExtensions
    {
        public static Room FindOrAddRoom(this AssetHubContext db, string name)
        {
            var room = (from r in db.Rooms
                        where r.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)
                        select r).FirstOrDefault();

            if (room == null)
            {
                room = new Room { Name = name };
                db.Rooms.Add(room);
                db.SaveChanges();
            }

            return room;
        }

        public static UserPosition FindOrAddUserPosition(this AssetHubContext db, string name)
        {
            var position = (from p in db.UserPositions
                            where p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)
                            select p).FirstOrDefault();

            if (position == null)
            {
                position = new UserPosition { Name = name };
                db.UserPositions.Add(position);
                db.SaveChanges();
            }

            return position;
        }

        public static ICollection<string> UserPositionList(this AssetHubContext db)
        {
            var list = (from p in db.UserPositions
                        select p.Name).ToList();

            return list;
        }

        public static ICollection<string> RoomList(this AssetHubContext db)
        {
            var list = (from r in db.Rooms
                        select r.Name).ToList();

            return list;
        }

        public static ICollection<string> CategoryList(this AssetHubContext db)
        {
            var list = (from c in db.AssetModelCategories
                        select c.Name).ToList();

            return list;
        }

        public static IEnumerable<SelectListItem> RoomDropdown(this AssetHubContext db)
        {
            var rooms = db.Rooms.Select(
                m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name,
                });

            return new SelectList(rooms, "Value", "Text");
        }

        public static IEnumerable<SelectListItem> UserPositionDropdown(this AssetHubContext db)
        {
            var rooms = db.UserPositions.Select(
                m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name,
                });

            return new SelectList(rooms, "Value", "Text");
        }

        public static IEnumerable<SelectListItem> AssetModelDropdown(this AssetHubContext db)
        {
            var assetModels = db.AssetModels.Select(
                m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name,
                });

            return new SelectList(assetModels, "Value", "Text");
        }

        public static IEnumerable<SelectListItem> CategoryDropdown(this AssetHubContext db)
        {
            var categories = db.AssetModelCategories.Select(
                m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name,
                });

            return new SelectList(categories, "Value", "Text");
        }
    }
}