using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace GlobalHotKey
{
    class ConfigClass
    {
        public enum CommandType { EXE, CMD, KEY };

        private string name;
        private KeyPair keyPairs;
        private CommandType type;
        private string exeFile;
        private string exeArg;
        private Keys targetKey;
        private string cmdLine;

        public ConfigClass(string _name, KeyPair _keyPairs, CommandType _type, string _exeFile, string _exeArg, Keys _targetKey, string _cmdLine) {
            name = _name;
            keyPairs = new KeyPair(_keyPairs);
            type = _type;
            exeFile = _exeFile;
            exeArg = _exeArg;
            targetKey = _targetKey;
            cmdLine = _cmdLine;
        }

        public string getName() { return name; }
        public KeyPair getKeyPairs() { return keyPairs; }
        public CommandType getType() { return type; }
        public string getExeFile() { return exeFile; }
        public string getExeArg() { return exeArg; }
        public Keys getTargetKey() { return targetKey; }
        public string getCmdLine() { return cmdLine; }

        public JObject getJObject() {
            JArray keypairs_arr = new JArray();
            foreach (Keys key in keyPairs) {
                keypairs_arr.Add((int)key);
            }
            JObject obj = new JObject();
            obj["name"] = name;
            obj["key_pairs"] = keypairs_arr;
            obj["type"] = type.ToString();
            obj["exe_file"] = exeFile;
            obj["exe_arg"] = exeArg;
            obj["target_key"] = (int)targetKey;
            obj["cmd_line"] = cmdLine;
            return obj;
        }
        public string serialize() {
            return getJObject().ToString();
        }
    }
}
