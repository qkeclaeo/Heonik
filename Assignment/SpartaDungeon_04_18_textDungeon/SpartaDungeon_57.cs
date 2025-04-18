// SpartaDungeon.cs
// [전체 구조 설명] 텍스트 기반 RPG 게임 메인 클래스 - 플레이어는 상점, 인벤토리, 던전을 오가며 성장함

using System;
using System.Collections.Generic;
using System.Linq;

namespace SpartaDungeon
{
    // [아이템 타입 정의] 무기/방어구/소모품을 구분하기 위한 열거형
    public enum ItemType { 무기, 방어구, 소모품 }

    // [아이템 클래스] 각각의 아이템 속성과 복제 메서드 정의
    public class Item
    {
        public string Name;
        public int AttackBonus;
        public int DefenseBonus;
        public string Description;
        public int Price;
        public ItemType Type;
        public bool IsEquipped;

        public Item(string name, int atk, int def, string desc, int price, ItemType type)
        {
            Name = name;
            AttackBonus = atk;
            DefenseBonus = def;
            Description = desc;
            Price = price;
            Type = type;
            IsEquipped = false;
        }

        // [아이템 복제] 인스턴스 복사를 위한 메서드
        public Item Clone()
        {
            return new Item(Name, AttackBonus, DefenseBonus, Description, Price, Type);
        }
    }

    // [플레이어 클래스] 플레이어의 능력치 및 인벤토리 관리
    public class Player
    {
        public string Name;
        public string Job;
        public double BaseAttack;
        public int BaseDefense;
        public int HP;
        public int Gold = 1500;
        public int Level = 1;
        public int DungeonClearCount = 0;
        public int BonusAttack = 0;
        public int BonusDefense = 0;
        public List<Item> Inventory = new List<Item>();

        // [총 공격력 계산] 장착 아이템과 보너스를 포함한 공격력 반환
        public double Attack
        {
            get { return BaseAttack + BonusAttack + Inventory.Where(i => i.IsEquipped).Sum(i => i.AttackBonus); }
        }

        // [총 방어력 계산] 장착 아이템과 보너스를 포함한 방어력 반환
        public int Defense
        {
            get { return BaseDefense + BonusDefense + Inventory.Where(i => i.IsEquipped).Sum(i => i.DefenseBonus); }
        }

        public Player(string name, string job, double baseAtk, int baseDef, int hp)
        {
            Name = name;
            Job = job;
            BaseAttack = baseAtk;
            BaseDefense = baseDef;
            HP = hp;
        }
    }

    // [메인 게임 클래스]
    class Program
    {
        static List<Item> ShopItems = new List<Item>(); // [상점 아이템 목록]
        static Random random = new Random(); // [랜덤 객체 생성]

        // [메인 메서드] 게임 시작 및 메인 루프
        static void Main(string[] args)
        {
            Console.Write("당신의 이름을 입력해주세요: ");
            string name = Console.ReadLine();

            Console.WriteLine("직업을 선택해주세요:");
            Console.WriteLine("1. 전사\n2. 궁수\n3. 마법사");
            string jobInput = Console.ReadLine();
            string job = jobInput == "2" ? "궁수" : jobInput == "3" ? "마법사" : "전사";

            Player player = new Player(name, job, 10, 5, 100);
            InitShopItems(); // [상점 초기화]

            // [게임 루프] 마을 메뉴 반복 출력
            while (true)
            {
                Console.WriteLine("=== 스파르타 마을 ===");
                Console.WriteLine("1. 상태보기\n2. 인벤토리\n3. 상점\n4. 던전 입장\n5. 휴식\n0. 종료");
                Console.Write("선택: ");
                string input = Console.ReadLine().Trim();

                if (input == "1") ShowStatus(player); // 상태 보기
                else if (input == "2") ShowInventory(player); // 인벤토리
                else if (input == "3") ShowStore(player); // 상점
                else if (input == "4") EnterDungeon(player); // 던전 입장
                else if (input == "5") Rest(player); // 휴식
                else if (input == "0") break; // 종료
                else Console.WriteLine("잘못된 입력입니다.");
            }

            Console.WriteLine("게임을 종료합니다. 아무 키나 누르세요");
            Console.ReadKey();
        }

        // [상점 아이템 초기화] 게임 시작 시 아이템 리스트 등록
        static void InitShopItems()
        {
            ShopItems.Add(new Item("판테온의 창", 100, 0, "과거 판테온 이라는 전설의 인물이 사용했던 창 입니다.", 9750, ItemType.무기));
            ShopItems.Add(new Item("스파르타의 창", 7, 0, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3500, ItemType.무기));
            ShopItems.Add(new Item("금 도끼", 5, 0, "어디선가 사용됐던 도끼입니다.", 2000, ItemType.무기));
            ShopItems.Add(new Item("판테온의 방패", 0, 100, "판테온 이라는 인물이 사용한 방패.", 9750, ItemType.방어구));
            ShopItems.Add(new Item("스파르타의 갑옷", 0, 15, "스파르타 전사의 갑옷.", 3500, ItemType.방어구));
            ShopItems.Add(new Item("무쇠 갑옷", 0, 9, "무쇠로 만들어진 방어구.", 2000, ItemType.방어구));
            ShopItems.Add(new Item("낡은 검", 2, 0, "쉽게 볼 수 있는 낡은 검입니다.", 600, ItemType.무기));
            ShopItems.Add(new Item("수련자 갑옷", 0, 5, "수련에 도움을 주는 갑옷입니다.", 1000, ItemType.방어구));
            ShopItems.Add(new Item("각성 포션", 0, 0, "공격력 +10", 5000, ItemType.소모품));
            ShopItems.Add(new Item("거북 포션", 0, 0, "방어력 +10", 5000, ItemType.소모품));
        }

        // [플레이어 상태 보기] 능력치, 골드 등 출력
        static void ShowStatus(Player player)
        {
            Console.WriteLine("=== 상태 ===");
            Console.WriteLine("이름: " + player.Name);
            Console.WriteLine("직업: " + player.Job);
            Console.WriteLine("레벨: " + player.Level);
            Console.WriteLine("공격력: " + player.Attack);
            Console.WriteLine("방어력: " + player.Defense);
            Console.WriteLine("체력: " + player.HP);
            Console.WriteLine("Gold: " + player.Gold + "G");
        }

        // [인벤토리 확인 및 장착/사용 처리]
        static void ShowInventory(Player player)
        {
            Console.WriteLine("=== 인벤토리 ===");
            if (player.Inventory.Count == 0)
            {
                Console.WriteLine("보유 중인 아이템이 없습니다.");
                Console.WriteLine("아무 키나 누르면 마을로 돌아갑니다");
                Console.ReadKey();
                return;
            }

            // 아이템 목록 출력 (장착된 경우 [E] 표시)
            for (int i = 0; i < player.Inventory.Count; i++)
            {
                Item item = player.Inventory[i];
                string marker = item.IsEquipped ? "[E] " : "";
                Console.WriteLine((i + 1) + ". " + marker + item.Name + " - " + item.Description);
            }

            Console.Write("아이템 번호 선택 (장착/사용) (0: 나가기): ");
            string input = Console.ReadLine();
            int index;
            if (int.TryParse(input, out index) && index > 0 && index <= player.Inventory.Count)
            {
                Item selected = player.Inventory[index - 1];
                if (selected.Type == ItemType.소모품)
                {
                    // 소모품 사용 시 효과 적용 및 인벤토리 제거
                    if (selected.Name.Contains("각성")) { player.BonusAttack += 10; Console.WriteLine("이 힘.. 내 안에 힘이 넘친다"); }
                    if (selected.Name.Contains("거북")) { player.BonusDefense += 10; Console.WriteLine("뭔가 단단해진 느낌이 든다.."); }
                    player.Inventory.Remove(selected);
                }
                else
                {
                    // 장비 장착/해제 처리
                    selected.IsEquipped = !selected.IsEquipped;
                    Console.WriteLine(selected.Name + (selected.IsEquipped ? " 장착했습니다." : " 장착 해제했습니다."));
                }
            }
        }

        // [상점 기능] 아이템 구매 처리
        static void ShowStore(Player player)
        {
            Console.WriteLine("=== 상점 ===");
            for (int i = 0; i < ShopItems.Count; i++)
            {
                Item item = ShopItems[i];
                Console.WriteLine((i + 1) + ". " + item.Name + " - " + item.Description + " (" + item.Price + "G)");
            }

            Console.Write("구매할 아이템 번호 (0: 나가기): ");
            string input = Console.ReadLine();
            int index;
            if (int.TryParse(input, out index) && index > 0 && index <= ShopItems.Count)
            {
                Item item = ShopItems[index - 1].Clone();
                if (player.Gold >= item.Price)
                {
                    player.Gold -= item.Price;
                    player.Inventory.Add(item);
                    Console.WriteLine(item.Name + "을(를) 구매했습니다!");
                }
                else Console.WriteLine("Gold가 부족합니다.");
            }
        }

        // [던전 입장 및 결과 처리]
        static void EnterDungeon(Player player)
        {
            Console.WriteLine("=== 던전 입장 ===");
            Console.WriteLine("던전에 입장합니다");
            Console.WriteLine("1. 쉬운 던전 (권장 방어력: 5)");
            Console.WriteLine("2. 일반 던전 (권장 방어력: 11)");
            Console.WriteLine("3. 어려운 던전 (권장 방어력: 17)");
            Console.Write("입장할 던전 번호 (0: 나가기): ");
            string input = Console.ReadLine().Trim();

            int defRequired = 0;
            int reward = 0;

            // 던전 난이도에 따른 방어력 요구치 및 보상 설정
            if (input == "1") { defRequired = 5; reward = 1000; }
            else if (input == "2") { defRequired = 11; reward = 1700; }
            else if (input == "3") { defRequired = 17; reward = 2500; }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 마을로 돌아갑니다");
                Console.ReadKey();
                return;
            }

            // 방어력 부족 시 40% 확률로 실패
            if (player.Defense < defRequired && random.Next(100) < 40)
            {
                player.HP /= 2;
                Console.WriteLine("던전 실패! 체력이 절반으로 감소했습니다.");
                Console.WriteLine("아무 키나 누르면 마을로 돌아갑니다");
                Console.ReadKey();
                return;
            }

            // 체력 감소 계산: 방어력 차이에 따른 피해량 계산
            int damage = Math.Max(5, random.Next(20, 36) - (player.Defense - defRequired));
            player.HP -= damage;

            // 공격력 기반 추가 보상 계산
            int bonus = reward * random.Next((int)player.Attack, (int)player.Attack * 2 + 1) / 100;
            int total = reward + bonus;
            player.Gold += total;

            Console.WriteLine("던전 클리어! 체력 -" + damage + ", 보상 +" + total + "G");
        }

        // [휴식 기능] 500G를 지불하여 체력 회복
        static void Rest(Player player)
        {
            Console.WriteLine("=== 휴식 ===");
            Console.WriteLine("500G를 지불하면 체력을 회복할 수 있습니다.");
            if (player.Gold >= 500)
            {
                player.Gold -= 500;
                player.HP = 100;
                Console.WriteLine("체력이 회복되었습니다. 현재 체력: " + player.HP);
            }
            else
            {
                Console.WriteLine("Gold가 부족합니다.");
            }
        }
    }
}
