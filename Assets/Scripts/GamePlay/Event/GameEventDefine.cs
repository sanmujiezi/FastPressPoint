namespace GamePlay.Event
{
    public class GameEventDefine
    {
        public struct  PanelSoltOn
        {
            
        } 
        public struct LevelTimeOut
        {
            
        }
        
        public struct LevelCompleted
        {
            
        }
        public struct GameStart
        {
            
        }
        
        public class GameLevelInfo
        {
            public float time;
            public int score;
        }
        public struct GameLevelCurTime
        {
            public float curTime;
        }
    }
}