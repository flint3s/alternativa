﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Database.Models
{
    public class CharacterAppearance
    {
        public CharacterAppearance(int motherId, int fatherId, float similarity, float skinSimilarity, List<float> faceFeatures)
        {
            MotherId = motherId;
            FatherId = fatherId;
            Similarity = similarity;
            SkinSimilarity = skinSimilarity;
            FaceFeatures = faceFeatures;
        }
        public CharacterAppearance(CharacterCreatorDto characterCreatorDto)
        {
            MotherId = characterCreatorDto.motherId;
            FatherId = characterCreatorDto.fatherId;
            Similarity = characterCreatorDto.similarity;
            SkinSimilarity = characterCreatorDto.skinSimilarity;
            FaceFeatures = characterCreatorDto.faceFeatures;
        }

        [JsonIgnore]

        public Guid Id { get; set; }
        
        [JsonIgnore]
        public Character Character { get; set; }
        public Guid CharacterId { get; set; }
        public int MotherId { get; set; }
        public int FatherId { get; set; }
        public float Similarity { get; set; }
        public float SkinSimilarity { get; set; }
        public List<float> FaceFeatures { get; set; }
        
        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}