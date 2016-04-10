﻿using AssetHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetHub.DAL
{
    public static class AssetHubContextExtensions
    {
        public static Room FindRoom(this AssetHubContext db, string name)
        {
            return (from r in db.Rooms
                        where r.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)
                        select r).FirstOrDefault();

        }

        public static Room AddRoom(this AssetHubContext db, string name)
        {
            var room = new Room { Name = name };
            db.Rooms.Add(room);
            db.SaveChanges();

            return room;
        }

        public static Room FindOrAddRoom(this AssetHubContext db, string name)
        {
            var room = db.FindRoom(name);
            if (room == null)
            {
                room = db.AddRoom(name);
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

        public static AssetModelProperty FindOrAddAssetModelProperty(this AssetHubContext db, string name)
        {
            var property = (from p in db.AssetModelProperties
                            where p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)
                            select p).FirstOrDefault();

            if (property == null)
            {
                property = new AssetModelProperty { Name = name };
                db.AssetModelProperties.Add(property);
                db.SaveChanges();
            }

            return property;
        }

        public static AssetModelCategory FindOrAddAssetModelCategory(this AssetHubContext db, string name)
        {
            var category = (from c in db.AssetModelCategories
                            where c.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)
                            select c).FirstOrDefault();

            if (category == null)
            {
                category = new AssetModelCategory { Name = name };
                db.AssetModelCategories.Add(category);
                db.SaveChanges();
            }

            return category;
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

        public static ICollection<string> PropertyList(this AssetHubContext db)
        {
            var list = (from p in db.AssetModelProperties
                        select p.Name).ToList();

            return list;
        }
    }
}