﻿namespace MapRepository.Core.AppSettings
{
    public class MinIoConfiguration
    {
        public string endpoint { get; set; } = string.Empty;
        public string mapRepositoryBucketName { get; set; } = string.Empty;
        public string missionMapBucketName { get; set; } = string.Empty;
    }
}
