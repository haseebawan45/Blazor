using System;
using System.Collections.Generic;
using System.Linq;
using SportsTracking.Models;

namespace SportsTracking.Services
{
    public class SportActivityService
    {
        private readonly List<SportActivity> _activities = new();

        public IReadOnlyList<SportActivity> Activities => _activities.AsReadOnly();

        public void AddActivity(SportActivity activity)
        {
            _activities.Add(activity);
        }

        public List<SportActivity> GetActivitiesBySportName(string sportName)
        {
            return _activities
                .Where(a => a.SportType == sportName)
                .ToList();
        }

        public HashSet<string> GetAvailableSports()
        {
            return _activities
                .Select(a => a.SportType)
                .ToHashSet();
        }

        public int GetTotalDurationBySport(string sportName)
        {
            return GetActivitiesBySportName(sportName)
                .Sum(a => a.DurationMinutes);
        }

        public double GetAveragePerformanceBySport(string sportName)
        {
            var activities = GetActivitiesBySportName(sportName);
            return activities.Any() 
                ? activities.Average(a => a.PerformanceRating) 
                : 0;
        }
    }
} 