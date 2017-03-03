using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace basichack
{
    class Manager
    {
        ProcessMemory Mem = new ProcessMemory("arma2oa");

        //Offsets
        const int OFF_Table = 0xDFCDD8;
        
        // const int objectTableAddr = OFF_Table;

        //StartProcess
        public bool managerStartProcess()
        {
            return Mem.StartProcess();
        }

        //Set Vision
        public void setVision(float range)
        {
            if (!Mem.CheckProcess())
            {
                return;
            }
            Mem.WriteFloat(0xE25718, range);
        }

        // Set NVGoggles
        public void setNvg()
        {
            if (!Mem.CheckProcess())
            {
                return;
            }
            int objTable = Mem.ReadInt(OFF_Table);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            objTablePtr = Mem.ReadInt(objTablePtr + 0x4);
            Mem.WriteInt(objTablePtr + 0xc16, 0x1);
        }

        // Set Thermal
        public void setThermal()
        {
            if (!Mem.CheckProcess())
            {
                return;
            }
            int objTable = Mem.ReadInt(OFF_Table);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            objTablePtr = Mem.ReadInt(objTablePtr + 0x4);
            Mem.WriteInt(objTablePtr + 0xc18, 0x1);
        }

        //Set Fatigue
        public void setFatigue()
        {
            if (!Mem.CheckProcess())
            {
                return;
            }
            int objTable = Mem.ReadInt(OFF_Table);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            objTablePtr = Mem.ReadInt(objTablePtr + 0x4);
            Mem.WriteInt(objTablePtr + 0xc44, 0);
        }

        //Set Recoil
        public void setRecoil()
        {
            if (!Mem.CheckProcess())
            {
                return;
            }
            int objTable = Mem.ReadInt(OFF_Table); // entityBase
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8); // address1
            objTablePtr = Mem.ReadInt(objTablePtr + 0x4); // address2
            Mem.WriteFloat(objTablePtr + 0xc28, 0f);
        }

        //Set Ammo
        public void setAmmo()
        {
            if (!Mem.CheckProcess())
            {
                return;
            }
            int objTable = Mem.ReadInt(OFF_Table);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            objTablePtr = Mem.ReadInt(objTablePtr + 0x4);

            int weaponID = Mem.ReadInt(objTablePtr + 0x6e0);

            int garbagePtr = Mem.ReadInt(objTablePtr + 0x694);
            garbagePtr = Mem.ReadInt(garbagePtr + ((weaponID * 0x24) + 0x4));

            int maxMag = Mem.ReadInt(garbagePtr + 0x8);

            uint maxMagCap = Mem.ReadUInt(maxMag + 0x2c);

            uint tmpCnt = ((uint)maxMagCap ^ (uint)0xBABAC8B6);
            uint maxCnt = tmpCnt << 1;
            Mem.WriteUInt(garbagePtr + 0x0C, tmpCnt - maxCnt);
            Mem.WriteUInt(garbagePtr + 0x24, maxCnt);
        }

        //Set Grass
        public void setGrass()
        {
            if (!Mem.CheckProcess())
            {
                return;
            }
            int Grass = Mem.ReadInt(OFF_Table);

            Mem.WriteFloat(Grass + 0x14F0, 50.0f);
        }

        //Set Repair
        public void setRepair()
        {
            if (!Mem.CheckProcess())
            {
                return;
            }
            int entity = getLocalPlayer();

            int partsAddress = Mem.ReadInt(entity + 0xC0);
            int p = Mem.ReadInt(entity + 0xc4);
            for (int i = 0; i < p; i++)
            {
                Mem.WriteFloat(partsAddress + i * 4, 0);
            }
        }

        //Set Refuel
        public void setRefuel()
        {
            if (!Mem.CheckProcess())
            {
                return;
            }
            int entity = getLocalPlayer();

            int fuelCapPtr = Mem.ReadInt(entity + 0x3C);
            float fuelCap = Mem.ReadFloat(fuelCapPtr + 0x600);

            int fuelLevelPtr = Mem.ReadInt(entity + 0x18);
            Mem.WriteFloat(fuelLevelPtr + 0xAC, fuelCap);
        }

        //Local Player
        public int getLocalPlayer()
        {
            int objTable = Mem.ReadInt(OFF_Table);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            return Mem.ReadInt(objTablePtr + 0x4);
        }

        // DayzMap методы

        string[] vehicleArray = new string[37] {
            "UH1H_DZ",
            "car_hatchback",
            "Tractor",
            "TT650_Ins",
            "TT650_Civ",
            "Old_bike_TK_CIV_EP1",
            "Old_bike_TK_INS_EP1",
            "Ikarus",
            "V3S_Civ",
            "Ural_TK_CIV_EP1",
            "Lada2",
            "UAZ_CDF",
            "Volha_2_TK_CIV_EP1",
            "hilux_civil_3_open",
            "hilux1_civil_3_open",
            "S1203_TK_CIV_EP1",
            "Smallboat_1",
            "smallboat_2",
            "PBX",
            "ATV_CZ_EP1",
            "ATV_US_EP1",
            "AH6X_DZ",
            "AN2_DZ"     ,       
            "ArmoredSUV_PMC_DZ",
            "ArmoredSUV_PMC_DZE",
            "CH_47F_EP1_DZ",
            "CH_47F_EP1_DZE",
            "CSJ_GyroC",
            "CSJ_GyroCover",
            "CSJ_GyroP",
            "CSJ_GyroP",
            "Fishing_Boat",
            "GAZ_Vodnik",
            "GAZ_Vodnik",
            "GAZ_Vodnik_DZ",
            "GAZ_Vodnik_DZE",
            "GAZ_Vodnik_MedEvac"
            /* Транспорт DayZ Epoch
            
            "GLT_M300_LT""
            GLT_M300_ST
            GLT_M300_ST
            HMMWV_Ambulance
            HMMWV_Ambulance_CZ_DES_EP
            HMMWV_DZ
            HMMWV_M1035_DES_EP1
            HMMWV_M1151_M2_CZ_DES_EP1
            HMMWV_M1151_M2_CZ_DES_EP1
            HMMWV_M1151_M2_CZ_DES_EP1_DZ
            HMMWV_M1151_M2_CZ_DES_EP1_DZE
            HMMWV_M1151_M2_DES_Base_EP1_DZ
            HMMWV_M1151_M2_DES_Base_EP1_DZE
            HMMWV_M998A2_SOV_DES_EP1
            HMMWV_M998A2_SOV_DES_EP1
            HMMWV_M998A2_SOV_DES_EP1_DZ
            HMMWV_M998A2_SOV_DES_EP1_DZE
            Ikarus_TK_CIV_EP1
            JetSkiYanahui_Case_Blue
            JetSkiYanahui_Case_Blue
            JetSkiYanahui_Case_Green
            JetSkiYanahui_Case_Green
            JetSkiYanahui_Case_Green
            JetSkiYanahui_Case_Red
            JetSkiYanahui_Case_Yellow
            Kamaz
            Kamaz
            KamazRefuel_DZ
            Lada1
            Lada1_TK_CIV_EP1
            Lada2
            Lada2_TK_CIV_EP1
            LadaLM
            LandRover_CZ_EP1
            LandRover_MG_TK_EP1
            LandRover_MG_TK_EP1_DZ
            LandRover_MG_TK_EP1_DZE
            LandRover_Special_CZ_EP1
            LandRover_Special_CZ_EP1_DZ
            LandRover_Special_CZ_EP1_DZE
            LandRover_TK_CIV_EP1
            M1030_US_DES_EP1
            M113Ambul_TK_EP1_DZ
            MH6J_DZ
            MMT_Civ
            
            MV22_DZ
            Mi17_Civilian_DZ
            Mi17_DZ
            Mi17_DZE
            MtvrRefuel_DES_EP1_DZ
            Offroad_DSHKM_Gue
            Offroad_DSHKM_Gue_DZ
            Offroad_DSHKM_Gue_DZE
            Offroad_DSHKM_Gue_DZE1
            Offroad_DSHKM_Gue_DZE2
            Offroad_DSHKM_Gue_DZE3
            Offroad_DSHKM_Gue_DZE4
            

PBX
Pickup_PK_GUE_DZ
Pickup_PK_GUE_DZE
Pickup_PK_INS
Pickup_PK_INS_DZ
Pickup_PK_INS_DZE
Pickup_PK_TK_GUE_EP1
Pickup_PK_TK_GUE_EP1_DZ
Pickup_PK_TK_GUE_EP1_DZE
RHIB_DZ
S1203_TK_CIV_EP1
SUV_Camo
SUV_Charcoal
SUV_Charcoal
SUV_Green
SUV_Pink
SUV_Red
SUV_Silver
SUV_TK_CIV_EP1
SUV_White
Skoda
SkodaBlue
SkodaBlue
SkodaGreen
SkodaGreen
SkodaRed
Smallboat_1
Soldier_Bodyguard_AA12_PM
TT650_Civ
TT650_Ins
TT650_TK_CIV_EP1
TT650_TK_CIV_EP1
TT650_TK_CIV_EP1
TT650_TK_CIV_EP1
Tractor
UAZ_CDF
UAZ_INS
UAZ_MG_TK_EP1
UAZ_MG_TK_EP1_DZ
UAZ_MG_TK_EP1_DZE
UAZ_RU
UAZ_RU
UAZ_Unarmed_TK_CIV_EP1
UAZ_Unarmed_UN_EP1
UH1H_DZ
UH1Y_DZ
UH60M_EP1_DZ
UH60M_EP1_DZE
UH60M_MEV_EP1
UralRefuel_TK_EP1_DZ
Ural_CDF
Ural_CDF
Ural_CDF
Ural_CDF
Ural_CDF
Ural_TK_CIV_EP1
Ural_UN_EP1
V3S_Civ
V3S_Open_TK_EP1
V3S_Open_TK_EP1
V3S_Open_TK_EP1
V3S_Refuel_TK_GUE_EP1_DZ
VWGolf
VWGolf
VolhaLimo_TK_CIV_EP1
VolhaLimo_TK_CIV_EP1
VolhaLimo_TK_CIV_EP1
VolhaLimo_TK_CIV_EP1
VolhaLimo_TK_CIV_EP1
VolhaLimo_TK_CIV_EP1
Volha_1_TK_CIV_EP1
Volha_2_TK_CIV_EP1
Zodiac
car_hatchback
car_sedan
car_sedan
datsun1_civil_1_open
datsun1_civil_1_open
datsun1_civil_2_covered
datsun1_civil_2_covered
datsun1_civil_3_open
datsun1_civil_3_open
hilux1_civil_2_covered
hilux1_civil_2_covered
hilux1_civil_3_open
hilux1_civil_3_open_EP1
hilux1_civil_3_open_EP1
"hilux1_civil_3_open_EP1"
"hilux_civil_3_open"
"policecar"
"smallboat_2"*/


        };

        string[] playerArray = new string[71] {
  
            "SurvivorW2_DZ",
            "Sniper1_DZ",
            "Camo1_DZ",
            "Bandit1_DZ",
            "Hero1_DZ",
            "Soldier1_DZ",
            "Rocket_DZ",
            //Люди DayZ Epoch
            "BAF_Soldier_AAR_DDPM",
            "BAF_Soldier_EN_MTP",
            "BAF_Soldier_Officer_DDPM",
            "Bandit1_DZ",
            "Bandit2_DZ",
            "BanditW1_DZ",
            "BanditW2_DZ",
            "CIV_EuroWoman02_EP1",
            "CZ_Soldier_Sniper_EP1_DZ",
            "CZ_Special_Forces_GL_DES_EP1_DZ",
            "Dr_Annie_Baker_EP1",
            "Drake",
            "Drake_Light_DZ",
            "FR_OHara_DZ",
            "FR_Rodriguez_DZ",
            "FR_Sykes",
            "Functionary1_EP1_DZ",
            "GUE_Commander",
            "GUE_Commander_DZ",
            "GUE_Soldier_1",
            "GUE_Soldier_2",
            "GUE_Soldier_2_DZ",
            "GUE_Soldier_3",
            "GUE_Soldier_CO",
            "GUE_Soldier_CO_DZ",
            "GUE_Soldier_Crew",
            "GUE_Soldier_Crew_DZ",
            "GUE_Soldier_MG_DZ",
            "GUE_Soldier_Sniper_DZ",
            "GUE_Villager4",
            "GUE_Worker2",
            "Graves_Light_DZ",
            "Haris_Press_EP1_DZ",
            "Herrera_Light",
            "Ins_Soldier_GL_DZ",
            "Pilot_EP1_DZ",
            "Priest_DZ",
            "RU_Damsel4",
            "RU_Policeman_DZ",
            "Rocker1_DZ",
            "Rocker2_DZ",
            "Rocker3_DZ",
            "Rocker4_DZ",
            "Soldier_Bodyguard_AA12_PMC_DZ",
            "Soldier_MG_PKM_PMC",
            "Soldier_MG_PMC",
            "Soldier_Sniper_PMC",
            "Soldier_Sniper_PMC_DZ",
            "Soldier_TL_PMC_DZ",
            "Survivor1_DZ",
            "SurvivorWcombat_DZ",
            "SurvivorWdesert_DZ",
            "SurvivorWpink_DZ",
            "SurvivorWurban_DZ",
            "TK_GUE_Soldier_5_EP1",
            "TK_GUE_Warlord_EP1",
            "TK_INS_Soldier_EP1_DZ",
            "TK_INS_Warlord_EP1_DZ",
            "Tanny_PMC",
            "UN_CDF_Soldier_Crew_EP1",
            "UN_CDF_Soldier_Pilot_EP1",
            "US_Delta_Force_AR_EP1",
            "US_Delta_Force_Marksman_E",
            "US_Delta_Force_Medic_EP1"
        };

        //Viewing Direction
        public static Image RotateImage(Image img, float rotationAngle)
        {
            Bitmap b = new Bitmap(img.Width, img.Height);
            Graphics graphic = Graphics.FromImage(b);
            graphic.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            graphic.RotateTransform(rotationAngle);
            graphic.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.DrawImage(img, new Point(0, 0));
            graphic.Dispose();
            return b;
        }

        public void getCurrentPlayer(object sender, PaintEventArgs e)
        {
            int objTable = Mem.ReadInt(OFF_Table);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A4);
            int objTablePtr1 = Mem.ReadInt(objTablePtr + 0x4);

            //Positions
            int coords = Mem.ReadInt(objTablePtr1 + 0x18);
            float LocX = ((Mem.ReadFloat(coords + 0x28)) / (15360.0f / 975.0f));
            float LocY = ((15360.0f - Mem.ReadFloat(coords + 0x30)) / (15360.0f / 970.0f));

            //Direction
            int direction = 0x01C;
            float Y = Mem.ReadFloat(coords + direction);
            float X = Mem.ReadFloat(coords + direction + 8);
            double Dir = Math.Atan2(Y, X) * (180 / Math.PI);
            if (Dir < 0) Dir = 360 + Dir;

            Image bmp = RotateImage(global::basichack.Properties.Resources.blue_arrow, (float)Dir);
            e.Graphics.DrawImage(bmp, LocX, LocY, 10, 15);
        }

        public void refreshMap(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(global::basichack.Properties.Resources.bigmap, 0, 0, 980, 980);
            if (!Mem.CheckProcess())
            {
                //arrowhead is not running
            }
            else
            {
                Mem.StartProcess();
                getCurrentPlayer(sender, e);

                int ObjTable = Mem.ReadInt(OFF_Table);
                int objTablePtr = Mem.ReadInt(ObjTable + 0x5FC);
                int objTableArrayPtr = Mem.ReadInt(objTablePtr + 0x0);
                int objTableSize = Mem.ReadInt(objTablePtr + 0x4);
                for (int i = 0; i < objTableSize; i++)
                {
                    int objPtr = Mem.ReadInt(objTableArrayPtr + (i * 52));
                    int obj1 = Mem.ReadInt(objPtr + 0x4);
                    int obj2 = Mem.ReadInt(obj1 + 0x3C);
                    int obj3 = Mem.ReadInt(obj2 + 0x30);

                    //Name
                    string objName = Mem.ReadStringAscii(obj3 + 0x8, 25);

                    //Dead
                    bool IsDead = (Mem.ReadByte(obj1 + 0x20C) > 0);

                    //Positions
                    int coords = Mem.ReadInt(obj1 + 0x18);
                    float LocX = ((Mem.ReadFloat(coords + 0x28)) / (15360.0f / 975.0f));
                    float LocY = ((15360.0f - Mem.ReadFloat(coords + 0x30)) / (15360.0f / 970.0f));

                    //Direction
                    int direction = 0x01C;
                    float Y = Mem.ReadFloat(coords + direction);
                    float X = Mem.ReadFloat(coords + direction + 8);
                    double Dir = Math.Atan2(Y, X) * (180 / Math.PI);
                    if (Dir < 0) Dir = 360 + Dir;

                    //Display on the Map
                    if (LocX > 0 && LocY > 0)
                    {
                        Font Arial = new Font("Arial", 8, FontStyle.Regular);

                        //Vehicles
                        if (vehicleArray.Contains(objName))
                        {
                            Brush redBrush = Brushes.Red;
                            e.Graphics.DrawString(objName, Arial, redBrush, LocX + 12, LocY + 3);

                            Image bmp = RotateImage(global::basichack.Properties.Resources.black_arrow, (float)Dir);
                            e.Graphics.DrawImage(bmp, LocX, LocY, 10, 15);
                        }
                        //Players
                        else if (playerArray.Contains(objName))
                        {
                            //Display if Player isn't dead
                            if (!IsDead)
                            {
                                Image bmp = RotateImage(global::basichack.Properties.Resources.red_arrow, (float)Dir);
                                e.Graphics.DrawImage(bmp, LocX, LocY, 10, 15);
                            }
                        }
                        /*Unknown
                        else
                        {
                            //Objects with names not in array
                            Brush greenBrush = Brushes.Green;
                            e.Graphics.DrawString(objName, Arial, greenBrush, LocX, LocY);
                            MessageBox.Show(objName);
                        }*/
                    }
                }
            }
        }

    }
}