﻿namespace Starwars.Abstraction.Dto.Character
{
    public class CharacterResponseDto
    {
        public string Name { get; set; }
        public string Planet { get; set; }
        public string[] Episodes { get; set; }
        public string[] Friends { get; set; }
    }
}
