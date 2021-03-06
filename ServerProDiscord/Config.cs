﻿using ServerProDiscord.ConfigSubClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet;
using YamlDotNet.Serialization;

namespace ServerProDiscord
{
    public static class Config
    {
        private static Map _map;

        public static string Token;

        public static bool DevEnv;
        public static RuntimeProfile Profile;
        public static ulong[] Admins;

        public static void Init(string configPath = "../../../../config.yml", string tokenPath = "../../../../token.txt")
        {
            var deserializer = new Deserializer();
            var configRaw = System.IO.File.ReadAllText(configPath);

            _map = deserializer.Deserialize<Map>(configRaw);

            DevEnv = _map.DevEnv;
            Profile = DevEnv ? _map.DevProfile : _map.ProdProfile;
            Admins = _map.Admins;

            Token = System.IO.File.ReadAllText(tokenPath);

            if (DevEnv)
            {
                Console.WriteLine("!!!  In developer mode  !!!");
                Console.WriteLine("!!! Real bot not online !!!\n");
            }
        }

        public class Map {
            public bool DevEnv;
            public RuntimeProfile DevProfile;
            public RuntimeProfile ProdProfile;
            public ulong[] Admins;
        }
    }
}
