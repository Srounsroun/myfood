﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myfoodapp.Hub.Models
{
    public class ProductionUnit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime startDate { get; set; }
        [Required]
        public string reference { get; set; }
        [Required]
        public ProductionUnitType productionUnitType { get; set; }
        [Required]
        public HydroponicType hydroponicType { get; set; }
        [Required]
        public double locationLatitude { get; set; }
        [Required]
        public double locationLongitude { get; set; }
        public String info { get; set; }
        public String version { get; set; }
        public List<Option> options { get; set; }
        [Required]
        public ProductionUnitOwner owner { get; set; }
        public string picturePath { get; set; }
        public List<Measure> measures { get; set; }
        public List<Event> events { get; set; }
        [Required]
        public ProductionUnitStatus productionUnitStatus { get; set; }
    }

    public class OptionList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ProductionUnit productionUnit { get; set; }
        public Option option { get; set; }
    }

    public class ProductionUnitOwner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ApplicationUser user { get; set; }
        public int pioneerCitizenNumber { get; set; }
        public string pioneerCitizenName { get; set; }
        public string notificationPushKey { get; set; }
    }

    public class ProductionUnitType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imagePath { get; set; }
    }

    public class ProductionUnitStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class HydroponicType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Option
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imagePath { get; set; }
    }

    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public ProductionUnit productionUnit { get; set; }
        [Required]
        public EventType eventType { get; set; }
    }

    public class EventType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}