using System;
using System.Collections.Generic;

namespace FootBall.Models
{
    public class Player
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public required string Position { get; set; }
        public required string Nationality { get; set; }
        public List<Stat> Stats { get; set; } = new List<Stat>();
        public List<Injury> Injuries { get; set; } = new List<Injury>();
    }

    public enum PlayerPosition
    {
        Goalkeeper,
        Defender,
        Midfielder,
        Forward
    }
} 