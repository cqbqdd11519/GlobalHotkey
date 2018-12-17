using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace GlobalHotKey
{
    class ConfigClass
    {
        public enum CommandType { CMD, KEY };

        private string name;
        private KeyPair keyPairs;
        private CommandType type;
        private string cmdFile;
        private string cmdArg;
        private Keys targetKey;

        public ConfigClass(string _name, KeyPair _keyPairs, CommandType _type, string _cmdFile, string _cmdArg, Keys _targetKey) {
            name = _name;
            keyPairs = new KeyPair(_keyPairs);
            type = _type;
            cmdFile = _cmdFile;
            cmdArg = _cmdArg;
            targetKey = _targetKey;
        }

        public string getName() { return name; }
        public KeyPair getKeyPairs() { return keyPairs; }
        public CommandType getType() { return type; }
        public string getCmdFile() { return cmdFile; }
        public string getCmdArg() { return cmdArg; }
        public Keys getTargetKey() { return targetKey; }

        public JObject getJObject() {
            JArray keypairs_arr = new JArray();
            foreach (Keys key in keyPairs) {
                keypairs_arr.Add((int)key);
            }
            JObject obj = new JObject();
            obj["name"] = name;
            obj["key_pairs"] = keypairs_arr;
            obj["type"] = type==CommandType.CMD ? "CMD" : "KEY";
            obj["cmd_file"] = cmdFile;
            obj["cmd_arg"] = cmdArg;
            obj["target_key"] = (int)targetKey;
            return obj;
        }
        public string serialize() {
            return getJObject().ToString();
        }
    }
}
