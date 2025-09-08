using UnityEngine;

namespace GamePlay
{
    public class LevelOprationCreater
    {
        private static LevelOprationCreater _instance;

        public static LevelOprationCreater Instance
        {
            get { return _instance ??= new LevelOprationCreater(); }
        }

        private LevelConfigOS _levelConfigOS;
        private GameObject _oprationPrafab;
        private GameObject _numsPrafab;
        private Transform _panelParent;

        public LevelOprationCreater()
        {
            _levelConfigOS = Resources.Load<LevelConfigOS>("Config/Level/LevelConfigOS");
            _numsPrafab = Resources.Load<GameObject>("Prefabs/GamePlay/PanelItem");
            _oprationPrafab = Resources.Load<GameObject>("Prefabs/GamePlay/OprationItem");
            _panelParent = GameObject.Find("UIGamePanel").transform.Find("Root/ControPanel/ItemGroup");
        }

        public void CreateLevelOpration(int levelId)
        {
            if (_levelConfigOS == null)
            {
                return;
            }

            foreach (var item in _levelConfigOS.levelInfos[levelId].blockInfos)
            {
                for (int i = 0; i < item.count; i++)
                {
                    CreateItem(item.nums);
                }
            }
        }

        private GameObject CreateItem(string itemNums)
        {
            GameObject obj = null;
            switch (itemNums)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    obj = GameObject.Instantiate(_oprationPrafab, _panelParent);
                    break;
                default:
                    obj = GameObject.Instantiate(_numsPrafab, _panelParent);
                    break;
            }

            return obj;
        }
    }
}