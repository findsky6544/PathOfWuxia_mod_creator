namespace 侠之道mod制作器
{
    class ComboBoxItem
    {
        private string _key;
        private string _value;


        public ComboBoxItem(string key, string value)
        {
            _key = key;
            _value = value;
        }

        public string key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
