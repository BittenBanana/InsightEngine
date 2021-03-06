﻿using Insight.Engine.Components;
using Insight.Materials;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine
{
    public class PathNode
    {
        public List<PathNode> neighbours;
        public Vector3 rootPoint;
        public int nodeID;
        public PathNode(Vector3 root, int id)
        {
            nodeID = id;
            rootPoint = root;
            neighbours = new List<PathNode>();
        }
        public PathNode()
        {
        }

        public void addNeighbour(PathNode node)
        {
            neighbours.Add(node);
        }
    }
    public class EnemyWalkingSpots
    {

        public List<GameObject> sceneNodes = new List<GameObject>();
        private static EnemyWalkingSpots instance = null;
        public static EnemyWalkingSpots getInstance()
        {
            if (instance == null)
                instance = new EnemyWalkingSpots();
            return instance;
        }
        static public List<PathNode> nodes;

        //Part1
        PathNode pathPoint1;
        PathNode pathPoint2;
        PathNode pathPoint3;
        PathNode pathPoint4;
        PathNode pathPoint5;
        PathNode pathPoint6;
        PathNode pathPoint7;
        PathNode pathPoint8;
        PathNode pathPoint9;
        PathNode pathPoint10;
        PathNode pathPoint11;
        PathNode pathPoint12;
        PathNode pathPoint13;
        PathNode pathPoint14;
        PathNode pathPoint15;
        PathNode pathPoint16;
        PathNode pathPoint17;
        PathNode pathPoint18;
        PathNode pathPoint19;
        PathNode pathPoint20;
        PathNode pathPoint21;
        PathNode pathPoint22;
        PathNode pathPoint23;
        PathNode pathPoint24;
        PathNode pathPoint25;
        PathNode pathPoint26;
        PathNode pathPoint27;
        PathNode pathPoint28;
        PathNode pathPoint29;

        //Room1
        PathNode pathPoint30;
        PathNode pathPoint31;
        PathNode pathPoint32;
        PathNode pathPoint33;
        PathNode pathPoint34;
        PathNode pathPoint35;
        PathNode pathPoint36;
        PathNode pathPoint37;
        PathNode pathPoint38;
        PathNode pathPoint39;
        PathNode pathPoint40;
        PathNode pathPoint41;
        PathNode pathPoint42;
        PathNode pathPoint43;
        PathNode pathPoint44;
        PathNode pathPoint45;
        PathNode pathPoint46;
        PathNode pathPoint47;
        PathNode pathPoint48;
        PathNode pathPoint49;
        PathNode pathPoint50;
        PathNode pathPoint51;
        PathNode pathPoint52;
        PathNode pathPoint53;
        PathNode pathPoint54;
        PathNode pathPoint55;
        PathNode pathPoint56;
        PathNode pathPoint57;
        PathNode pathPoint58;
        PathNode pathPoint59;
        PathNode pathPoint60;

        PathNode pathPoint61;
        PathNode pathPoint62;
        PathNode pathPoint63;
        PathNode pathPoint64;
        PathNode pathPoint65;
        PathNode pathPoint66;
        PathNode pathPoint67;
        PathNode pathPoint68;
        PathNode pathPoint69;
        PathNode pathPoint70;

        PathNode pathPoint71;
        PathNode pathPoint72;
        PathNode pathPoint73;
        PathNode pathPoint74;
        PathNode pathPoint75;
        PathNode pathPoint76;
        PathNode pathPoint77;
        PathNode pathPoint78;
        PathNode pathPoint79;
        PathNode pathPoint80;

        PathNode pathPoint81;
        PathNode pathPoint82;
        PathNode pathPoint83;
        PathNode pathPoint84;
        PathNode pathPoint85;
        PathNode pathPoint86;
        PathNode pathPoint87;
        PathNode pathPoint88;
        PathNode pathPoint89;
        PathNode pathPoint90;

        PathNode pathPoint91;
        PathNode pathPoint92;
        PathNode pathPoint93;
        PathNode pathPoint94;

        PathNode pathPoint95;
        PathNode pathPoint96;
        PathNode pathPoint97;
        PathNode pathPoint98;
        PathNode pathPoint99;
        PathNode pathPoint100;

        PathNode pathPoint101;
        PathNode pathPoint102;
        PathNode pathPoint103;
        PathNode pathPoint104;
        PathNode pathPoint105;
        PathNode pathPoint106;
        PathNode pathPoint107;
        PathNode pathPoint108;
        PathNode pathPoint109;
        PathNode pathPoint110;

        PathNode pathPoint111;
        PathNode pathPoint112;
        PathNode pathPoint113;
        PathNode pathPoint114;
        PathNode pathPoint115;
        PathNode pathPoint116;
        PathNode pathPoint117;
        PathNode pathPoint118;
        PathNode pathPoint119;
        PathNode pathPoint120;

        PathNode pathPoint121;
        PathNode pathPoint122;
        PathNode pathPoint123;
        PathNode pathPoint124;
        PathNode pathPoint125;
        PathNode pathPoint126;
        PathNode pathPoint127;
        PathNode pathPoint128;
        PathNode pathPoint129;
        PathNode pathPoint130;

        PathNode pathPoint131;
        PathNode pathPoint132;
        PathNode pathPoint133;
        PathNode pathPoint134;
        PathNode pathPoint135;
        PathNode pathPoint136;
        PathNode pathPoint137;
        PathNode pathPoint138;
        PathNode pathPoint139;
        PathNode pathPoint140;

        PathNode pathPoint141;
        PathNode pathPoint142;
        PathNode pathPoint143;
        PathNode pathPoint144;
        PathNode pathPoint145;

        public EnemyWalkingSpots()
        {
            nodes = new List<PathNode>();
            //part1
            pathPoint1 = new PathNode(new Vector3(2.5f, 0, 0), 1);
            pathPoint2 = new PathNode(new Vector3(2.5f, 0, 5), 2);
            pathPoint3 = new PathNode(new Vector3(2.5f, 0, 9.5f), 3);
            pathPoint4 = new PathNode(new Vector3(3, 0, 11.5f), 4);
            pathPoint5 = new PathNode(new Vector3(5.5f, 0, 13f), 5);
            pathPoint6 = new PathNode(new Vector3(10, 0, 13.5f), 6);
            pathPoint7 = new PathNode(new Vector3(18.5f, 0, 13.5f), 7);
            pathPoint8 = new PathNode(new Vector3(18.5f, 0, 6), 8);
            pathPoint9 = new PathNode(new Vector3(18.5f, 0, 3.5f), 9);
            pathPoint10 = new PathNode(new Vector3(25, 0, 13.5f), 10);
            pathPoint11 = new PathNode(new Vector3(30, 0, 13.5f), 11);
            pathPoint12 = new PathNode(new Vector3(33.5f, 0, 14.5f), 12);
            pathPoint13 = new PathNode(new Vector3(34, 0, 16.5f), 13);
            pathPoint14 = new PathNode(new Vector3(34, 0, 20), 14);

            pathPoint15 = new PathNode(new Vector3(3.5f, 0, 12.5f), 15);
            pathPoint16 = new PathNode(new Vector3(4.5f, 0, 13), 16);
            pathPoint17 = new PathNode(new Vector3(8.0f, 0, 12.5f), 17);
            pathPoint18 = new PathNode(new Vector3(13, 0, 13.5f), 18);
            pathPoint19 = new PathNode(new Vector3(17f, 0, 13.5f), 19);
            pathPoint20 = new PathNode(new Vector3(21, 0, 13.5f), 20);
            pathPoint21 = new PathNode(new Vector3(18.5f, 0, 12.5f), 21);
            pathPoint22 = new PathNode(new Vector3(18.5f, 0, 11f), 22);
            pathPoint23 = new PathNode(new Vector3(18.5f, 0, 8.5f), 23);
            pathPoint24 = new PathNode(new Vector3(2.5f, 0, 7.5f), 24);
            pathPoint25 = new PathNode(new Vector3(2.5f, 0, 2.5f), 25);
            pathPoint26 = new PathNode(new Vector3(16f, 0, 13.5f), 26);
            pathPoint27 = new PathNode(new Vector3(23, 0, 13.5f), 27);
            pathPoint28 = new PathNode(new Vector3(28, 0, 13.5f), 28);
            pathPoint29 = new PathNode(new Vector3(32, 0, 14), 29);

            //Room1
            pathPoint30 = new PathNode(new Vector3(34.5f, 0, 22.5f), 30);

            pathPoint31 = new PathNode(new Vector3(34.5f, 0, 23), 31);

            pathPoint32 = new PathNode(new Vector3(33.5f, 0, 23f), 32);

            pathPoint33 = new PathNode(new Vector3(32.5f, 0, 23f), 33);

            pathPoint34 = new PathNode(new Vector3(31.5f, 0, 23f), 34);

            pathPoint35 = new PathNode(new Vector3(30, 0, 23f), 35);

            pathPoint36 = new PathNode(new Vector3(28.5f, 0, 23f), 36);

            pathPoint37 = new PathNode(new Vector3(28.5f, 0, 25), 37);

            pathPoint38 = new PathNode(new Vector3(29.5f, 0, 25f), 38);
            ////
            pathPoint39 = new PathNode(new Vector3(30.5f, 0, 25f), 39);

            pathPoint40 = new PathNode(new Vector3(31.5f, 0, 25f), 40);

            pathPoint41 = new PathNode(new Vector3(33f, 0, 25f), 41);

            pathPoint42 = new PathNode(new Vector3(34.5f, 0, 25f), 42);

            pathPoint43 = new PathNode(new Vector3(36, 0, 23), 43);

            pathPoint44 = new PathNode(new Vector3(37.5f, 0, 23f), 44);

            pathPoint45 = new PathNode(new Vector3(39, 0, 23f), 45);

            pathPoint46 = new PathNode(new Vector3(41f, 0, 23f), 46);

            //
            pathPoint47 = new PathNode(new Vector3(41f, 0, 24), 47);

            pathPoint48 = new PathNode(new Vector3(40f, 0, 25f), 48);

            pathPoint49 = new PathNode(new Vector3(38.5f, 0, 24.5f), 49);

            pathPoint50 = new PathNode(new Vector3(36.5f, 0, 25f), 50);


            pathPoint51 = new PathNode(new Vector3(41.3f, 0, 27.5f), 51);

            pathPoint52 = new PathNode(new Vector3(39.5f, 0, 27.5f), 52);

            pathPoint53 = new PathNode(new Vector3(38.5f, 0, 27.5f), 53);

            pathPoint54 = new PathNode(new Vector3(36.5f, 0, 27.5f), 54);

            pathPoint55 = new PathNode(new Vector3(35.3f, 0, 27.5f), 55);

            pathPoint56 = new PathNode(new Vector3(35.5f, 0, 29.5f), 56);

            pathPoint57 = new PathNode(new Vector3(36.5f, 0, 29.5f), 57);

            pathPoint58 = new PathNode(new Vector3(37.5f, 0, 29.5f), 58);

            pathPoint59 = new PathNode(new Vector3(39.3f, 0, 29.5f), 59);

            pathPoint60 = new PathNode(new Vector3(41f, 0, 29.5f), 60);


            pathPoint61 = new PathNode(new Vector3(42.5f, 0, 28.5f), 61);

            pathPoint62 = new PathNode(new Vector3(44f, 0, 28f), 62);

            pathPoint63 = new PathNode(new Vector3(44f, 0, 29.5f), 63);

            pathPoint64 = new PathNode(new Vector3(44f, 0, 31f), 64);

            pathPoint65 = new PathNode(new Vector3(42.5f, 0, 31f), 65);

            pathPoint66 = new PathNode(new Vector3(42.5f, 0, 29.5f), 66);

            pathPoint67 = new PathNode(new Vector3(41.5f, 0, 31.5f), 67);

            pathPoint68 = new PathNode(new Vector3(40.5f, 0, 31.5f), 68);

            pathPoint69 = new PathNode(new Vector3(39f, 0, 31.5f), 69);

            pathPoint70 = new PathNode(new Vector3(37.5f, 0, 31.5f), 70);


            pathPoint71 = new PathNode(new Vector3(35.5f, 0, 31), 71);

            pathPoint72 = new PathNode(new Vector3(35.5f, 0, 32.5f), 72);

            pathPoint73 = new PathNode(new Vector3(35.5f, 0, 32f), 73);

            pathPoint74 = new PathNode(new Vector3(37f, 0, 32.5f), 74);

            pathPoint75 = new PathNode(new Vector3(38.5f, 0, 32.5f), 75);

            pathPoint76 = new PathNode(new Vector3(40.5f, 0, 32.5f), 76);

            pathPoint77 = new PathNode(new Vector3(41f, 0, 34), 77);

            pathPoint78 = new PathNode(new Vector3(39.5f, 0, 34f), 78);

            pathPoint79 = new PathNode(new Vector3(37f, 0, 34f), 79);

            pathPoint80 = new PathNode(new Vector3(38.5f, 0, 34f), 80);


            pathPoint81 = new PathNode(new Vector3(35.5f, 0, 34.5f), 81);

            pathPoint82 = new PathNode(new Vector3(33f, 0, 34.5f), 82);

            pathPoint83 = new PathNode(new Vector3(31.5f, 0, 34f), 83);

            pathPoint84 = new PathNode(new Vector3(29.5f, 0, 34f), 84);

            pathPoint85 = new PathNode(new Vector3(28.5f, 0, 34f), 85);

            pathPoint86 = new PathNode(new Vector3(28.5f, 0, 35.5f), 86);
            
            pathPoint87 = new PathNode(new Vector3(29.5f, 0, 35.5f), 87);
            
            pathPoint88 = new PathNode(new Vector3(31f, 0, 35.5f), 88);
            
            pathPoint89 = new PathNode(new Vector3(32.5f, 0, 35.5f), 89);
            
            pathPoint90 = new PathNode(new Vector3(33.5f, 0, 35.5f), 90);
            

            pathPoint91 = new PathNode(new Vector3(35.5f, 0, 36), 91);
            pathPoint92 = new PathNode(new Vector3(37.5f, 0, 36f), 92);
            pathPoint93 = new PathNode(new Vector3(39f, 0, 36.3f), 93);
            pathPoint94 = new PathNode(new Vector3(40.5f, 0, 36f), 94);
            //new
            pathPoint95 = new PathNode(new Vector3(30f, 0, 37.5f), 95);
            pathPoint96 = new PathNode(new Vector3(29f, 0, 37.5f), 96);
            pathPoint97 = new PathNode(new Vector3(30f, 0, 38.5f), 97);
            pathPoint98 = new PathNode(new Vector3(29f, 0, 38.5f), 98);
            pathPoint99 = new PathNode(new Vector3(29f, 0, 40f), 99);
            pathPoint100 = new PathNode(new Vector3(30f, 0, 40f), 100);

            pathPoint101 = new PathNode(new Vector3(29f, 0, 41.5f), 101);
            pathPoint102 = new PathNode(new Vector3(30f, 0, 41.5f), 102);
            pathPoint103 = new PathNode(new Vector3(29f, 0, 43f), 103);
            pathPoint104 = new PathNode(new Vector3(30f, 0, 43f), 104);
            pathPoint105 = new PathNode(new Vector3(29f, 0, 44.5f), 105);
            pathPoint106 = new PathNode(new Vector3(30f, 0, 44.5f), 106);
            pathPoint107 = new PathNode(new Vector3(29f, 0, 46.5f), 107);
            pathPoint108 = new PathNode(new Vector3(30f, 0, 36.5f), 108);
            pathPoint109 = new PathNode(new Vector3(28.5f, 0, 48f), 109);
            pathPoint110 = new PathNode(new Vector3(30f, 0, 48f), 120);

            pathPoint111 = new PathNode(new Vector3(28.5f, 0, 50), 111);
            pathPoint112 = new PathNode(new Vector3(30f, 0, 50f), 112);
            pathPoint113 = new PathNode(new Vector3(26f, 0, 48.5f), 113);
            pathPoint114 = new PathNode(new Vector3(23.5f, 0, 48.5f), 114);
            pathPoint115 = new PathNode(new Vector3(23.5f, 0, 50.5f), 115);
            pathPoint116 = new PathNode(new Vector3(26f, 0, 50.5f), 116);
            pathPoint117 = new PathNode(new Vector3(21f, 0, 49f), 117);
            pathPoint118 = new PathNode(new Vector3(19f, 0, 50f), 118);
            pathPoint119 = new PathNode(new Vector3(18f, 0, 52.2f), 119);
            pathPoint120 = new PathNode(new Vector3(19.5f, 0, 52.2f), 120);

            pathPoint121 = new PathNode(new Vector3(23f, 0, 50.5f), 121);
            pathPoint122 = new PathNode(new Vector3(19.7f, 0, 50.8f), 122);
            pathPoint123 = new PathNode(new Vector3(17.5f, 0, 53.5f), 123);
            pathPoint124 = new PathNode(new Vector3(17.5f, 0, 56f), 124);
            pathPoint125 = new PathNode(new Vector3(19.5f, 0, 56f), 125);
            pathPoint126 = new PathNode(new Vector3(19.5f, 0, 53.5f), 126);
            pathPoint127 = new PathNode(new Vector3(18.5f, 0, 57f), 127);
            pathPoint128 = new PathNode(new Vector3(32.5f, 0, 50.5f), 128);
            pathPoint129 = new PathNode(new Vector3(34f, 0, 52f), 129);
            pathPoint130 = new PathNode(new Vector3(35.5f, 0, 52f), 130);

            pathPoint131 = new PathNode(new Vector3(35f, 0, 50.2f), 131);
            pathPoint132 = new PathNode(new Vector3(33f, 0, 49f), 132);
            pathPoint133 = new PathNode(new Vector3(34.5f, 0, 51f), 133);
            pathPoint134 = new PathNode(new Vector3(34.5f, 0, 53.5f), 134);
            pathPoint135 = new PathNode(new Vector3(34.5f, 0, 56.5f), 135);
            pathPoint136 = new PathNode(new Vector3(36f, 0, 56.8f), 136);
            pathPoint137 = new PathNode(new Vector3(36.5f, 0, 54f), 137);
            pathPoint138 = new PathNode(new Vector3(35f, 0, 58.8f), 138);
            pathPoint139 = new PathNode(new Vector3(35.5f, 0, 61f), 139);
            pathPoint140 = new PathNode(new Vector3(37.5f, 0, 62f), 140);

            pathPoint141 = new PathNode(new Vector3(48.5f, 0, 61.5f), 141);
            pathPoint142 = new PathNode(new Vector3(48.5f, 0, 61.5f), 141);
            pathPoint143 = new PathNode(new Vector3(37.8f, 0, 60.3f), 142);
            pathPoint144 = new PathNode(new Vector3(36.9f, 0, 59f), 143);
            pathPoint145 = new PathNode(new Vector3(36.8f, 0, 60.1f), 144);


            nodes.Add(pathPoint1);
            nodes.Add(pathPoint2);
            nodes.Add(pathPoint3);
            nodes.Add(pathPoint4);
            nodes.Add(pathPoint5);
            nodes.Add(pathPoint6);
            nodes.Add(pathPoint7);
            nodes.Add(pathPoint8);
            nodes.Add(pathPoint9);
            nodes.Add(pathPoint10);
            nodes.Add(pathPoint11);
            nodes.Add(pathPoint12);
            nodes.Add(pathPoint13);
            nodes.Add(pathPoint14);

            nodes.Add(pathPoint15);
            nodes.Add(pathPoint16);
            nodes.Add(pathPoint17);
            nodes.Add(pathPoint18);
            nodes.Add(pathPoint19);
            nodes.Add(pathPoint20);
            nodes.Add(pathPoint21);
            nodes.Add(pathPoint22);
            nodes.Add(pathPoint23);
            nodes.Add(pathPoint24);
            nodes.Add(pathPoint25);
            nodes.Add(pathPoint26);
            nodes.Add(pathPoint27);
            nodes.Add(pathPoint28);
            nodes.Add(pathPoint29);




            nodes.Add(pathPoint30);
            nodes.Add(pathPoint31);
            nodes.Add(pathPoint32);
            nodes.Add(pathPoint33);
            nodes.Add(pathPoint34);
            nodes.Add(pathPoint35);
            nodes.Add(pathPoint36);
            nodes.Add(pathPoint37);
            nodes.Add(pathPoint38);
            nodes.Add(pathPoint39);
            nodes.Add(pathPoint40);
            nodes.Add(pathPoint41);
            nodes.Add(pathPoint42);
            nodes.Add(pathPoint43);
            nodes.Add(pathPoint44);
            nodes.Add(pathPoint45);
            nodes.Add(pathPoint46);
            nodes.Add(pathPoint47);
            nodes.Add(pathPoint48);
            nodes.Add(pathPoint49);
            nodes.Add(pathPoint50);
            nodes.Add(pathPoint51);
            nodes.Add(pathPoint52);
            nodes.Add(pathPoint53);
            nodes.Add(pathPoint54);
            nodes.Add(pathPoint55);
            nodes.Add(pathPoint56);
            nodes.Add(pathPoint57);
            nodes.Add(pathPoint58);
            nodes.Add(pathPoint59);
            nodes.Add(pathPoint60);
            nodes.Add(pathPoint61);
            nodes.Add(pathPoint62);
            nodes.Add(pathPoint63);
            nodes.Add(pathPoint64);
            nodes.Add(pathPoint65);
            nodes.Add(pathPoint66);
            nodes.Add(pathPoint67);
            nodes.Add(pathPoint68);
            nodes.Add(pathPoint69);
            nodes.Add(pathPoint70);
            nodes.Add(pathPoint71);
            nodes.Add(pathPoint72);
            nodes.Add(pathPoint73);
            nodes.Add(pathPoint74);
            nodes.Add(pathPoint75);
            nodes.Add(pathPoint76);
            nodes.Add(pathPoint77);
            nodes.Add(pathPoint78);
            nodes.Add(pathPoint79);
            nodes.Add(pathPoint80);
            nodes.Add(pathPoint81);
            nodes.Add(pathPoint82);
            nodes.Add(pathPoint83);
            nodes.Add(pathPoint84);
            nodes.Add(pathPoint85);
            nodes.Add(pathPoint86);
            nodes.Add(pathPoint87);
            nodes.Add(pathPoint88);
            nodes.Add(pathPoint89);
            nodes.Add(pathPoint90);
            nodes.Add(pathPoint91);
            nodes.Add(pathPoint92);
            nodes.Add(pathPoint93);
            nodes.Add(pathPoint94);
            nodes.Add(pathPoint95);
            nodes.Add(pathPoint96);
            nodes.Add(pathPoint97);
            nodes.Add(pathPoint98);
            nodes.Add(pathPoint99);
            nodes.Add(pathPoint100);

            nodes.Add(pathPoint101);
            nodes.Add(pathPoint102);
            nodes.Add(pathPoint103);
            nodes.Add(pathPoint104);
            nodes.Add(pathPoint105);
            nodes.Add(pathPoint106);
            nodes.Add(pathPoint107);
            nodes.Add(pathPoint108);
            nodes.Add(pathPoint109);
            nodes.Add(pathPoint110);

            nodes.Add(pathPoint111);
            nodes.Add(pathPoint112);
            nodes.Add(pathPoint113);
            nodes.Add(pathPoint114);
            nodes.Add(pathPoint115);
            nodes.Add(pathPoint116);
            nodes.Add(pathPoint117);
            nodes.Add(pathPoint118);
            nodes.Add(pathPoint119);
            nodes.Add(pathPoint120);

            nodes.Add(pathPoint121);
            nodes.Add(pathPoint122);
            nodes.Add(pathPoint123);
            nodes.Add(pathPoint124);
            nodes.Add(pathPoint125);
            nodes.Add(pathPoint126);
            nodes.Add(pathPoint127);
            nodes.Add(pathPoint128);
            nodes.Add(pathPoint129);
            nodes.Add(pathPoint130);

            nodes.Add(pathPoint131);
            nodes.Add(pathPoint132);
            nodes.Add(pathPoint133);
            nodes.Add(pathPoint134);
            nodes.Add(pathPoint135);
            nodes.Add(pathPoint136);
            nodes.Add(pathPoint137);
            nodes.Add(pathPoint138);
            nodes.Add(pathPoint139);
            nodes.Add(pathPoint140);

            nodes.Add(pathPoint141);
            nodes.Add(pathPoint142);
            nodes.Add(pathPoint143);
            nodes.Add(pathPoint144);
            nodes.Add(pathPoint145);

            AddNeighbourToNode(1, 25);
            AddNeighbourToNode(25, 1);
            AddNeighbourToNode(25, 2);
            AddNeighbourToNode(2, 25);
            AddNeighbourToNode(2, 22);
            AddNeighbourToNode(24, 3);
            AddNeighbourToNode(24, 2);
            AddNeighbourToNode(3, 24);
            AddNeighbourToNode(3, 4);
            AddNeighbourToNode(4, 15);
            AddNeighbourToNode(4, 3);
            AddNeighbourToNode(15, 16);
            AddNeighbourToNode(15, 4);
            AddNeighbourToNode(16, 5);
            AddNeighbourToNode(16, 15);
            AddNeighbourToNode(5, 17);
            AddNeighbourToNode(5, 16);
            AddNeighbourToNode(17, 5);
            AddNeighbourToNode(17, 6);
            AddNeighbourToNode(6, 18);
            AddNeighbourToNode(6, 17);
            AddNeighbourToNode(18, 26);
            AddNeighbourToNode(18, 6);
            AddNeighbourToNode(26, 19);
            AddNeighbourToNode(26, 18);
            AddNeighbourToNode(19, 7);
            AddNeighbourToNode(19, 26);
            AddNeighbourToNode(7, 19);
            AddNeighbourToNode(7, 21);
            AddNeighbourToNode(7, 20);

            AddNeighbourToNode(21, 7);
            AddNeighbourToNode(21, 22);
            AddNeighbourToNode(22, 21);
            AddNeighbourToNode(22, 23);
            AddNeighbourToNode(23, 22);
            AddNeighbourToNode(23, 8);
            AddNeighbourToNode(8, 23);
            AddNeighbourToNode(8, 9);
            AddNeighbourToNode(9, 8);

            AddNeighbourToNode(20, 7);
            AddNeighbourToNode(20, 27);
            AddNeighbourToNode(27, 20);
            AddNeighbourToNode(27, 10);
            AddNeighbourToNode(10, 27);
            AddNeighbourToNode(10, 28);
            AddNeighbourToNode(28, 11);
            AddNeighbourToNode(28, 10);
            AddNeighbourToNode(11, 28);
            AddNeighbourToNode(11, 29);
            AddNeighbourToNode(29, 11);
            AddNeighbourToNode(29, 12);
            AddNeighbourToNode(12, 29);
            AddNeighbourToNode(12, 13);
            AddNeighbourToNode(13, 12);
            AddNeighbourToNode(13, 14);
            AddNeighbourToNode(14, 13);

            AddNeighbourToNode(14, 30);

            AddNeighbourToNode(30, 14);
            AddNeighbourToNode(30, 43);
            AddNeighbourToNode(30, 31);
            AddNeighbourToNode(30, 32);
            AddNeighbourToNode(31, 30);
            AddNeighbourToNode(31, 32);
            AddNeighbourToNode(31, 43);
            AddNeighbourToNode(31, 41);
            AddNeighbourToNode(31, 42);
            AddNeighbourToNode(31, 40);
            AddNeighbourToNode(32, 30);
            AddNeighbourToNode(32, 31);
            AddNeighbourToNode(32, 41);
            AddNeighbourToNode(32, 40);
            AddNeighbourToNode(32, 39);
            AddNeighbourToNode(32, 33);
            AddNeighbourToNode(33, 32);
            AddNeighbourToNode(33, 34);
            AddNeighbourToNode(33, 38);
            AddNeighbourToNode(33, 39);
            AddNeighbourToNode(33, 40);
            AddNeighbourToNode(34, 33);
            AddNeighbourToNode(34, 35);
            AddNeighbourToNode(34, 37);
            AddNeighbourToNode(34, 38);
            AddNeighbourToNode(34, 39);
            AddNeighbourToNode(35, 34);
            AddNeighbourToNode(35, 36);
            AddNeighbourToNode(35, 37);
            AddNeighbourToNode(35, 38);
            AddNeighbourToNode(36, 35);
            AddNeighbourToNode(36, 37);
            AddNeighbourToNode(36, 38);
            AddNeighbourToNode(37, 36);
            AddNeighbourToNode(37, 35);
            AddNeighbourToNode(37, 38);
            AddNeighbourToNode(38, 37);
            AddNeighbourToNode(38, 39);
            AddNeighbourToNode(38, 33);
            AddNeighbourToNode(38, 34);

            AddNeighbourToNode(39, 38);
            AddNeighbourToNode(39, 34);
            AddNeighbourToNode(39, 33);
            AddNeighbourToNode(39, 32);
            AddNeighbourToNode(39, 40);
            AddNeighbourToNode(40, 39);
            AddNeighbourToNode(40, 33);
            AddNeighbourToNode(40, 32);
            AddNeighbourToNode(40, 31);
            AddNeighbourToNode(40, 41);
            AddNeighbourToNode(41, 40);
            AddNeighbourToNode(41, 42);
            AddNeighbourToNode(41, 31);
            AddNeighbourToNode(41, 32);
            AddNeighbourToNode(41, 43);
            AddNeighbourToNode(42, 41);
            AddNeighbourToNode(42, 32);
            AddNeighbourToNode(42, 31);
            AddNeighbourToNode(42, 43);
            AddNeighbourToNode(42, 59);
            AddNeighbourToNode(42, 55);
            AddNeighbourToNode(42, 54);
            AddNeighbourToNode(43, 30);
            AddNeighbourToNode(43, 31);
            AddNeighbourToNode(43, 42);
            AddNeighbourToNode(43, 50);
            AddNeighbourToNode(43, 49);
            AddNeighbourToNode(43, 44);
            AddNeighbourToNode(44, 43);
            AddNeighbourToNode(44, 50);
            AddNeighbourToNode(44, 49);
            AddNeighbourToNode(44, 48);
            AddNeighbourToNode(44, 45);
            AddNeighbourToNode(45, 44);
            AddNeighbourToNode(45, 46);
            AddNeighbourToNode(45, 47);
            AddNeighbourToNode(45, 48);
            AddNeighbourToNode(45, 49);
            AddNeighbourToNode(46, 45);
            AddNeighbourToNode(46, 48);
            AddNeighbourToNode(46, 47);
            AddNeighbourToNode(47, 46);
            AddNeighbourToNode(47, 48);
            AddNeighbourToNode(47, 45);
            AddNeighbourToNode(47, 51);
            AddNeighbourToNode(47, 52);
            AddNeighbourToNode(48, 49);
            AddNeighbourToNode(48, 44);
            AddNeighbourToNode(48, 45);
            AddNeighbourToNode(48, 46);
            AddNeighbourToNode(48, 47);
            AddNeighbourToNode(48, 51);
            AddNeighbourToNode(48, 52);
            AddNeighbourToNode(48, 53);
            AddNeighbourToNode(48, 54);
            AddNeighbourToNode(49, 50);
            AddNeighbourToNode(49, 43);
            AddNeighbourToNode(49, 44);
            AddNeighbourToNode(49, 45);
            AddNeighbourToNode(49, 48);
            AddNeighbourToNode(49, 52);
            AddNeighbourToNode(49, 53);
            AddNeighbourToNode(49, 54);
            AddNeighbourToNode(50, 42);
            AddNeighbourToNode(50, 31);
            AddNeighbourToNode(50, 43);
            AddNeighbourToNode(50, 44);
            AddNeighbourToNode(50, 49);
            AddNeighbourToNode(50, 53);
            AddNeighbourToNode(50, 54);
            AddNeighbourToNode(50, 55);
            AddNeighbourToNode(51, 52);
            AddNeighbourToNode(51, 48);
            AddNeighbourToNode(51, 47);
            AddNeighbourToNode(51, 61);
            AddNeighbourToNode(51, 66);
            AddNeighbourToNode(51, 60);
            AddNeighbourToNode(51, 59);
            AddNeighbourToNode(52, 53);
            AddNeighbourToNode(52, 49);
            AddNeighbourToNode(52, 48);
            AddNeighbourToNode(52, 47);
            AddNeighbourToNode(52, 51);
            AddNeighbourToNode(52, 60);
            AddNeighbourToNode(52, 59);
            AddNeighbourToNode(52, 58);
            AddNeighbourToNode(53, 54);
            AddNeighbourToNode(53, 50);
            AddNeighbourToNode(53, 49);
            AddNeighbourToNode(53, 48);
            AddNeighbourToNode(53, 52);
            AddNeighbourToNode(53, 59);
            AddNeighbourToNode(53, 58);
            AddNeighbourToNode(53, 57);
            AddNeighbourToNode(54, 55);
            AddNeighbourToNode(54, 50);
            AddNeighbourToNode(54, 49);
            AddNeighbourToNode(54, 53);
            AddNeighbourToNode(54, 58);
            AddNeighbourToNode(54, 57);
            AddNeighbourToNode(54, 56);
            AddNeighbourToNode(54, 42);
            AddNeighbourToNode(55, 41);
            AddNeighbourToNode(55, 42);
            AddNeighbourToNode(55, 50);
            AddNeighbourToNode(55, 54);
            AddNeighbourToNode(55, 57);
            AddNeighbourToNode(55, 56);
            AddNeighbourToNode(56, 55);
            AddNeighbourToNode(56, 54);
            AddNeighbourToNode(56, 57);
            AddNeighbourToNode(56, 70);
            AddNeighbourToNode(56, 71);
            AddNeighbourToNode(57, 56);
            AddNeighbourToNode(57, 55);
            AddNeighbourToNode(57, 54);
            AddNeighbourToNode(57, 53);
            AddNeighbourToNode(57, 58);
            AddNeighbourToNode(57, 69);
            AddNeighbourToNode(57, 70);
            AddNeighbourToNode(57, 71);
            AddNeighbourToNode(58, 57);
            AddNeighbourToNode(58, 54);
            AddNeighbourToNode(58, 53);
            AddNeighbourToNode(58, 52);
            AddNeighbourToNode(58, 59);
            AddNeighbourToNode(58, 68);
            AddNeighbourToNode(58, 69);
            AddNeighbourToNode(58, 70);
            AddNeighbourToNode(59, 58);
            AddNeighbourToNode(59, 53);
            AddNeighbourToNode(59, 52);
            AddNeighbourToNode(59, 51);
            AddNeighbourToNode(59, 60);
            AddNeighbourToNode(59, 67);
            AddNeighbourToNode(59, 68);
            AddNeighbourToNode(59, 69);
            AddNeighbourToNode(60, 59);
            AddNeighbourToNode(60, 52);
            AddNeighbourToNode(60, 51);
            AddNeighbourToNode(60, 61);
            AddNeighbourToNode(60, 66);
            AddNeighbourToNode(60, 65);
            AddNeighbourToNode(60, 67);
            AddNeighbourToNode(60, 68);
            AddNeighbourToNode(61, 51);
            AddNeighbourToNode(61, 62);
            AddNeighbourToNode(61, 63);
            AddNeighbourToNode(61, 66);
            AddNeighbourToNode(61, 60);
            AddNeighbourToNode(62, 61);
            AddNeighbourToNode(62, 63);
            AddNeighbourToNode(62, 66);
            AddNeighbourToNode(63, 66);
            AddNeighbourToNode(63, 61);
            AddNeighbourToNode(63, 62);
            AddNeighbourToNode(63, 63);
            AddNeighbourToNode(63, 64);
            AddNeighbourToNode(63, 65);
            AddNeighbourToNode(64, 65);
            AddNeighbourToNode(64, 66);
            AddNeighbourToNode(64, 63);
            AddNeighbourToNode(65, 67);
            AddNeighbourToNode(65, 60);
            AddNeighbourToNode(65, 66);
            AddNeighbourToNode(65, 63);
            AddNeighbourToNode(65, 64);
            AddNeighbourToNode(66, 60);
            AddNeighbourToNode(66, 51);
            AddNeighbourToNode(66, 61);
            AddNeighbourToNode(66, 62);
            AddNeighbourToNode(66, 63);
            AddNeighbourToNode(66, 64);
            AddNeighbourToNode(66, 65);
            AddNeighbourToNode(66, 67);
            AddNeighbourToNode(67, 68);
            AddNeighbourToNode(67, 59);
            AddNeighbourToNode(67, 60);
            AddNeighbourToNode(67, 66);
            AddNeighbourToNode(67, 65);
            AddNeighbourToNode(67, 76);
            AddNeighbourToNode(68, 69);
            AddNeighbourToNode(68, 58);
            AddNeighbourToNode(68, 59);
            AddNeighbourToNode(68, 60);
            AddNeighbourToNode(68, 67);
            AddNeighbourToNode(68, 76);
            AddNeighbourToNode(68, 75);
            AddNeighbourToNode(68, 74);
            AddNeighbourToNode(69, 70);
            AddNeighbourToNode(69, 57);
            AddNeighbourToNode(69, 58);
            AddNeighbourToNode(69, 59);
            AddNeighbourToNode(69, 68);
            AddNeighbourToNode(69, 76);
            AddNeighbourToNode(69, 75);
            AddNeighbourToNode(69, 74);
            AddNeighbourToNode(70, 71);
            AddNeighbourToNode(70, 56);
            AddNeighbourToNode(70, 57);
            AddNeighbourToNode(70, 58);
            AddNeighbourToNode(70, 69);
            AddNeighbourToNode(70, 75);
            AddNeighbourToNode(70, 74);
            AddNeighbourToNode(70, 73);
            AddNeighbourToNode(71, 56);
            AddNeighbourToNode(71, 57);
            AddNeighbourToNode(71, 70);
            AddNeighbourToNode(71, 74);
            AddNeighbourToNode(71, 73);
            AddNeighbourToNode(71, 72);
            AddNeighbourToNode(72, 71);
            AddNeighbourToNode(72, 70);
            AddNeighbourToNode(72, 73);
            AddNeighbourToNode(72, 80);
            AddNeighbourToNode(72, 81);
            AddNeighbourToNode(73, 72);
            AddNeighbourToNode(73, 71);
            AddNeighbourToNode(73, 70);
            AddNeighbourToNode(73, 69);
            AddNeighbourToNode(73, 74);
            AddNeighbourToNode(73, 78);
            AddNeighbourToNode(73, 79);
            AddNeighbourToNode(73, 80);
            AddNeighbourToNode(74, 50);
            AddNeighbourToNode(74, 43);
            AddNeighbourToNode(74, 44);
            AddNeighbourToNode(74, 45);
            AddNeighbourToNode(74, 48);
            AddNeighbourToNode(74, 52);
            AddNeighbourToNode(74, 53);
            AddNeighbourToNode(74, 54);
            AddNeighbourToNode(75, 74);
            AddNeighbourToNode(75, 70);
            AddNeighbourToNode(75, 69);
            AddNeighbourToNode(75, 68);
            AddNeighbourToNode(75, 76);
            AddNeighbourToNode(75, 77);
            AddNeighbourToNode(75, 78);
            AddNeighbourToNode(75, 79);
            AddNeighbourToNode(76, 75);
            AddNeighbourToNode(76, 68);
            AddNeighbourToNode(76, 67);
            AddNeighbourToNode(76, 77);
            AddNeighbourToNode(76, 78);
            AddNeighbourToNode(77, 78);
            AddNeighbourToNode(77, 75);
            AddNeighbourToNode(77, 76);
            AddNeighbourToNode(77, 94);
            AddNeighbourToNode(77, 93);
            AddNeighbourToNode(78, 79);
            AddNeighbourToNode(78, 73);
            AddNeighbourToNode(78, 74);
            AddNeighbourToNode(78, 75);
            AddNeighbourToNode(78, 77);
            AddNeighbourToNode(78, 94);
            AddNeighbourToNode(78, 93);
            AddNeighbourToNode(78, 92);
            AddNeighbourToNode(79, 80);
            AddNeighbourToNode(79, 72);
            AddNeighbourToNode(79, 73);
            AddNeighbourToNode(79, 74);
            AddNeighbourToNode(79, 78);
            AddNeighbourToNode(79, 93);
            AddNeighbourToNode(79, 92);
            AddNeighbourToNode(79, 91);
            AddNeighbourToNode(80, 81);
            AddNeighbourToNode(80, 72);
            AddNeighbourToNode(80, 73);
            AddNeighbourToNode(80, 79);
            AddNeighbourToNode(80, 92);
            AddNeighbourToNode(80, 91);
            AddNeighbourToNode(80, 90);
            AddNeighbourToNode(80, 74);
            AddNeighbourToNode(81, 82);
            AddNeighbourToNode(81, 72);
            AddNeighbourToNode(81, 73);
            AddNeighbourToNode(81, 79);
            AddNeighbourToNode(81, 92);
            AddNeighbourToNode(81, 91);
            AddNeighbourToNode(81, 90);
            AddNeighbourToNode(81, 89);
            AddNeighbourToNode(82, 83);
            AddNeighbourToNode(82, 72);
            AddNeighbourToNode(82, 81);
            AddNeighbourToNode(82, 90);
            AddNeighbourToNode(82, 89);
            AddNeighbourToNode(82, 88);
            AddNeighbourToNode(83, 84);
            AddNeighbourToNode(83, 82);
            AddNeighbourToNode(83, 89);
            AddNeighbourToNode(83, 88);
            AddNeighbourToNode(83, 87);
            AddNeighbourToNode(84, 85);
            AddNeighbourToNode(84, 83);
            AddNeighbourToNode(84, 88);
            AddNeighbourToNode(84, 87);
            AddNeighbourToNode(84, 86);
            AddNeighbourToNode(85, 84);
            AddNeighbourToNode(85, 87);
            AddNeighbourToNode(85, 86);
            AddNeighbourToNode(86, 85);
            AddNeighbourToNode(86, 84);
            AddNeighbourToNode(86, 87);
            AddNeighbourToNode(87, 86);
            AddNeighbourToNode(87, 85);
            AddNeighbourToNode(87, 84);
            AddNeighbourToNode(87, 83);
            AddNeighbourToNode(87, 88);
            AddNeighbourToNode(88, 87);
            AddNeighbourToNode(88, 84);
            AddNeighbourToNode(88, 83);
            AddNeighbourToNode(88, 82);
            AddNeighbourToNode(88, 89);
            AddNeighbourToNode(89, 88);
            AddNeighbourToNode(89, 83);
            AddNeighbourToNode(89, 82);
            AddNeighbourToNode(89, 81);
            AddNeighbourToNode(89, 90);
            AddNeighbourToNode(90, 89);
            AddNeighbourToNode(90, 82);
            AddNeighbourToNode(90, 81);
            AddNeighbourToNode(90, 80);
            AddNeighbourToNode(90, 91);
            AddNeighbourToNode(91, 90);
            AddNeighbourToNode(91, 80);
            AddNeighbourToNode(91, 79);
            AddNeighbourToNode(91, 92);
            AddNeighbourToNode(91, 81);
            AddNeighbourToNode(92, 91);
            AddNeighbourToNode(92, 80);
            AddNeighbourToNode(92, 79);
            AddNeighbourToNode(92, 78);
            AddNeighbourToNode(92, 93);
            AddNeighbourToNode(93, 92);
            AddNeighbourToNode(93, 79);
            AddNeighbourToNode(93, 78);
            AddNeighbourToNode(93, 77);
            AddNeighbourToNode(93, 94);
            AddNeighbourToNode(94, 93);
            AddNeighbourToNode(94, 78);
            AddNeighbourToNode(94, 77);
            //
            AddNeighbourToNode(95, 96);
            AddNeighbourToNode(95, 98);
            AddNeighbourToNode(95, 97);

            AddNeighbourToNode(96, 98);
            AddNeighbourToNode(96, 97);
            AddNeighbourToNode(96, 95);

            AddNeighbourToNode(97, 98);
            AddNeighbourToNode(97, 96);
            AddNeighbourToNode(97, 95);
            AddNeighbourToNode(97, 100);
            AddNeighbourToNode(97, 99);

            AddNeighbourToNode(98, 96);
            AddNeighbourToNode(98, 95);
            AddNeighbourToNode(98, 97);
            AddNeighbourToNode(98, 100);
            AddNeighbourToNode(98, 99);

            AddNeighbourToNode(99, 98);
            AddNeighbourToNode(99, 97);
            AddNeighbourToNode(99, 100);
            AddNeighbourToNode(99, 102);
            AddNeighbourToNode(99, 101);

            AddNeighbourToNode(100, 99);
            AddNeighbourToNode(100, 98);
            AddNeighbourToNode(100, 97);
            AddNeighbourToNode(100, 102);
            AddNeighbourToNode(100, 101);

            AddNeighbourToNode(101, 99);
            AddNeighbourToNode(101, 100);
            AddNeighbourToNode(101, 102);
            AddNeighbourToNode(101, 104);
            AddNeighbourToNode(101, 103);

            AddNeighbourToNode(102, 101);
            AddNeighbourToNode(102, 99);
            AddNeighbourToNode(102, 100);
            AddNeighbourToNode(102, 104);
            AddNeighbourToNode(102, 103);

            AddNeighbourToNode(103, 101);
            AddNeighbourToNode(103, 102);
            AddNeighbourToNode(103, 104);
            AddNeighbourToNode(103, 106);
            AddNeighbourToNode(103, 105);

            AddNeighbourToNode(104, 103);
            AddNeighbourToNode(104, 101);
            AddNeighbourToNode(104, 102);
            AddNeighbourToNode(104, 106);
            AddNeighbourToNode(104, 105);

            AddNeighbourToNode(105, 103);
            AddNeighbourToNode(105, 104);
            AddNeighbourToNode(105, 106);
            AddNeighbourToNode(105, 108);
            AddNeighbourToNode(105, 107);

            AddNeighbourToNode(106, 105);
            AddNeighbourToNode(106, 103);
            AddNeighbourToNode(106, 104);
            AddNeighbourToNode(106, 108);
            AddNeighbourToNode(106, 107);

            AddNeighbourToNode(107, 105);
            AddNeighbourToNode(107, 106);
            AddNeighbourToNode(107, 108);
            AddNeighbourToNode(107, 110);
            AddNeighbourToNode(107, 109);

            AddNeighbourToNode(108, 107);
            AddNeighbourToNode(108, 105);
            AddNeighbourToNode(108, 106);
            AddNeighbourToNode(108, 110);
            AddNeighbourToNode(108, 109);

            AddNeighbourToNode(109, 113);
            AddNeighbourToNode(109, 107);
            AddNeighbourToNode(109, 108);
            AddNeighbourToNode(109, 110);
            AddNeighbourToNode(109, 112);
            AddNeighbourToNode(109, 111);
            AddNeighbourToNode(109, 116);

            AddNeighbourToNode(110, 109);
            AddNeighbourToNode(110, 107);
            AddNeighbourToNode(110, 108);
            AddNeighbourToNode(110, 132);
            AddNeighbourToNode(110, 128);
            AddNeighbourToNode(110, 112);
            AddNeighbourToNode(110, 111);

            AddNeighbourToNode(111, 116);
            AddNeighbourToNode(111, 113);
            AddNeighbourToNode(111, 109);
            AddNeighbourToNode(111, 110);
            AddNeighbourToNode(111, 112);

            AddNeighbourToNode(112, 111);
            AddNeighbourToNode(112, 109);
            AddNeighbourToNode(112, 110);
            AddNeighbourToNode(112, 132);
            AddNeighbourToNode(112, 128);

            AddNeighbourToNode(113, 114);
            AddNeighbourToNode(113, 109);
            AddNeighbourToNode(113, 111);
            AddNeighbourToNode(113, 116);
            AddNeighbourToNode(113, 115);

            AddNeighbourToNode(114, 117);
            AddNeighbourToNode(114, 113);
            AddNeighbourToNode(114, 116);
            AddNeighbourToNode(114, 115);
            AddNeighbourToNode(114, 121);

            AddNeighbourToNode(115, 121);
            AddNeighbourToNode(115, 117);
            AddNeighbourToNode(115, 113);
            AddNeighbourToNode(115, 116);
            AddNeighbourToNode(115, 115);

            AddNeighbourToNode(116, 115);
            AddNeighbourToNode(116, 114);
            AddNeighbourToNode(116, 113);
            AddNeighbourToNode(116, 109);
            AddNeighbourToNode(116, 111);

            AddNeighbourToNode(117, 118);
            AddNeighbourToNode(117, 114);
            AddNeighbourToNode(117, 115);
            AddNeighbourToNode(117, 121);
            AddNeighbourToNode(117, 122);

            AddNeighbourToNode(118, 119);
            AddNeighbourToNode(118, 117);
            AddNeighbourToNode(118, 121);
            AddNeighbourToNode(118, 122);

            AddNeighbourToNode(119, 118);
            AddNeighbourToNode(119, 122);
            AddNeighbourToNode(119, 120);
            AddNeighbourToNode(119, 126);
            AddNeighbourToNode(119, 123);

            AddNeighbourToNode(120, 119);
            AddNeighbourToNode(120, 122);
            AddNeighbourToNode(120, 121);
            AddNeighbourToNode(120, 126);
            AddNeighbourToNode(120, 123);

            AddNeighbourToNode(121, 122);
            AddNeighbourToNode(121, 117);
            AddNeighbourToNode(121, 114);
            AddNeighbourToNode(121, 115);
            AddNeighbourToNode(121, 120);

            AddNeighbourToNode(122, 118);
            AddNeighbourToNode(122, 117);
            AddNeighbourToNode(122, 121);
            AddNeighbourToNode(122, 120);
            AddNeighbourToNode(122, 119);

            AddNeighbourToNode(123, 119);
            AddNeighbourToNode(123, 120);
            AddNeighbourToNode(123, 126);
            AddNeighbourToNode(123, 125);
            AddNeighbourToNode(123, 124);

            AddNeighbourToNode(124, 123);
            AddNeighbourToNode(124, 126);
            AddNeighbourToNode(124, 125);
            AddNeighbourToNode(124, 127);

            AddNeighbourToNode(125, 124);
            AddNeighbourToNode(125, 123);
            AddNeighbourToNode(125, 126);
            AddNeighbourToNode(125, 127);

            AddNeighbourToNode(126, 123);
            AddNeighbourToNode(126, 120);
            AddNeighbourToNode(126, 125);
            AddNeighbourToNode(126, 124);
            AddNeighbourToNode(126, 119);

            AddNeighbourToNode(127, 125);
            AddNeighbourToNode(127, 124);

            AddNeighbourToNode(128, 112);
            AddNeighbourToNode(128, 110);
            AddNeighbourToNode(128, 132);
            AddNeighbourToNode(128, 133);
            AddNeighbourToNode(128, 129);

            AddNeighbourToNode(129, 128);
            AddNeighbourToNode(129, 133);
            AddNeighbourToNode(129, 130);
            AddNeighbourToNode(129, 137);
            AddNeighbourToNode(129, 134);

            AddNeighbourToNode(130, 129);
            AddNeighbourToNode(130, 133);
            AddNeighbourToNode(130, 131);
            AddNeighbourToNode(130, 137);
            AddNeighbourToNode(130, 134);

            AddNeighbourToNode(131, 132);
            AddNeighbourToNode(131, 130);
            AddNeighbourToNode(131, 129);
            AddNeighbourToNode(131, 133);

            AddNeighbourToNode(132, 131);
            AddNeighbourToNode(132, 133);
            AddNeighbourToNode(132, 110);
            AddNeighbourToNode(132, 108);

            AddNeighbourToNode(133, 128);
            AddNeighbourToNode(133, 132);
            AddNeighbourToNode(133, 131);
            AddNeighbourToNode(133, 130);
            AddNeighbourToNode(133, 129);

            AddNeighbourToNode(134, 129);
            AddNeighbourToNode(134, 130);
            AddNeighbourToNode(134, 137);
            AddNeighbourToNode(134, 136);
            AddNeighbourToNode(134, 135);

            AddNeighbourToNode(135, 134);
            AddNeighbourToNode(135, 137);
            AddNeighbourToNode(135, 136);
            AddNeighbourToNode(135, 144);
            AddNeighbourToNode(135, 138);

            AddNeighbourToNode(136, 135);
            AddNeighbourToNode(136, 134);
            AddNeighbourToNode(136, 137);
            AddNeighbourToNode(136, 144);
            AddNeighbourToNode(136, 138);

            AddNeighbourToNode(137, 134);
            AddNeighbourToNode(137, 129);
            AddNeighbourToNode(137, 130);
            AddNeighbourToNode(137, 136);
            AddNeighbourToNode(137, 135);

            AddNeighbourToNode(138, 135);
            AddNeighbourToNode(138, 136);
            AddNeighbourToNode(138, 144);
            AddNeighbourToNode(138, 145);
            AddNeighbourToNode(138, 139);

            AddNeighbourToNode(139, 138);
            AddNeighbourToNode(139, 145);
            AddNeighbourToNode(139, 140);

            AddNeighbourToNode(140, 139);
            AddNeighbourToNode(140, 145);
            AddNeighbourToNode(140, 144);
            AddNeighbourToNode(140, 143);
            AddNeighbourToNode(140, 141);
            AddNeighbourToNode(140, 142);

            AddNeighbourToNode(141, 140);
            AddNeighbourToNode(141, 143);
            AddNeighbourToNode(141, 142);

            AddNeighbourToNode(142, 140);
            AddNeighbourToNode(142, 143);
            AddNeighbourToNode(142, 141);


            AddNeighbourToNode(143, 145);
            AddNeighbourToNode(143, 144);
            AddNeighbourToNode(143, 141);
            AddNeighbourToNode(143, 140);
            AddNeighbourToNode(143, 142);

            AddNeighbourToNode(144, 138);
            AddNeighbourToNode(144, 135);
            AddNeighbourToNode(144, 136);
            AddNeighbourToNode(144, 143);
            AddNeighbourToNode(144, 145);

            AddNeighbourToNode(145, 138);
            AddNeighbourToNode(145, 144);
            AddNeighbourToNode(145, 143);
            AddNeighbourToNode(145, 140);
            AddNeighbourToNode(145, 139);

            AddNeighbourToNode(87, 95);
            AddNeighbourToNode(87, 96);

            AddNeighbourToNode(95, 87);
            AddNeighbourToNode(96, 87);


            Debug.WriteLine(nodes.Count);

            sceneNodes = SpawnNodesOnMap();


        }

        public Vector3 findNearestPathToPlayer(Vector3 currentPosition, List<int> visitedPath)
        {
            PathNode enemyNearbyNode = findNearestNode(currentPosition);
            Vector3 playerPosition = SceneManager.Instance.currentScene.player.Transform.Position;

            float distance = 9999.0f;
            PathNode destNode = new PathNode();
            foreach (PathNode node in enemyNearbyNode.neighbours)
            {
                float tmpDist = Vector3.Distance(node.rootPoint, playerPosition);
                if (tmpDist < distance)
                {
                    distance = tmpDist;
                    destNode = node;
                }
            }
            return destNode.rootPoint;
        }

        public Vector3 findNearestPath(Vector3 currentPosition, Vector3 destPath)
        {
            PathNode enemyNearbyNode = findNearestNode(currentPosition);

            float distance = 9999.0f;
            PathNode destNode = new PathNode();
            foreach (PathNode node in enemyNearbyNode.neighbours)
            {
                float tmpDist = Vector2.Distance(new Vector2(node.rootPoint.X, node.rootPoint.Z), new Vector2(destPath.X, destPath.Z));
                if (tmpDist < distance)
                {
                    distance = tmpDist;
                    destNode = node;
                }
            }
            return destNode.rootPoint;
        }

        public PathNode findNearestNode(Vector3 pos)
        {
            float distance = 9999.0f;
            PathNode nearestNode = new PathNode();
            foreach (PathNode node in nodes)
            {
                float tmpDist = Vector2.Distance(new Vector2(node.rootPoint.X,node.rootPoint.Z), new Vector2(pos.X, pos.Z));
                if (tmpDist < distance)
                {
                    distance = tmpDist;
                    nearestNode = node;
                }
            }
            return nearestNode;
        }
        

        public void MoveGameObjectToDestination(GameObject gObject, Vector3 targetDestination, float speed, float stopValue)
        {
            Vector3 nearest = gObject.Transform.Position;
            Vector3 direction = new Vector3();
            float angle = 0;
            if (Vector2.Distance(new Vector2(gObject.Transform.Position.X, gObject.Transform.Position.Z), new Vector2(targetDestination.X, targetDestination.Z)) <= stopValue)
            {
                //Face player
                direction = SceneManager.Instance.currentScene.player.Transform.Position - gObject.Transform.Position;
                angle = (float)(Math.Atan2(direction.X, direction.Z));
                gObject.Transform.Rotation.Y = angle;
                return;
            }

            if (Vector2.Distance(new Vector2(nearest.X, nearest.Z), new Vector2(gObject.Transform.Position.X, gObject.Transform.Position.Z)) <= 0.1f)
                nearest = findNearestPath(gObject.Transform.Position, targetDestination);
            if (Vector2.Distance(new Vector2(nearest.X, nearest.Z), new Vector2(gObject.Transform.Position.X, gObject.Transform.Position.Z)) > 0.1f)
            {
                direction = nearest - gObject.Transform.Position;
                angle = (float)(Math.Atan2(direction.X, direction.Z));
                gObject.Transform.Position = VectorHelper.MoveTowards(gObject.Transform.Position, nearest, speed);
            }
            gObject.Transform.Rotation.Y = angle;

        }

        public float DistanceFromDestination(Vector3 currentPosition, Vector3 targetDestination)
        {
            PathNode nearestNodeFromCurrent = findNearestNode(currentPosition);
            PathNode nearestNodeFromDestination = findNearestNode(targetDestination);
            PathNode currentNode = nearestNodeFromCurrent;
            int maxNodes = 0;
            float distance = 0.0f;
            while (currentNode.nodeID != nearestNodeFromDestination.nodeID)
            {
                PathNode nearest = new PathNode();
                float dist = 9999.0f;
                foreach (PathNode node in currentNode.neighbours)
                {
                    if (Vector2.Distance(new Vector2(node.rootPoint.X, node.rootPoint.Z), new Vector2(targetDestination.X,targetDestination.Z)) < dist)
                    {
                        dist = Vector2.Distance(new Vector2(node.rootPoint.X, node.rootPoint.Z), new Vector2(targetDestination.X, targetDestination.Z));
                        nearest = node;
                    }
                }
                distance += Vector2.Distance(new Vector2(currentNode.rootPoint.X, currentNode.rootPoint.Z), new Vector2(nearest.rootPoint.X, nearest.rootPoint.Z));
                currentNode = nearest;
                maxNodes++;

                if (maxNodes > 15)
                    return 9999.0f;
            }
            return distance;
        }

        public List<GameObject> SpawnNodesOnMap()
        {
            List<GameObject> nodeObjects = new List<GameObject>();
            foreach (PathNode node in nodes)
            {
                nodeObjects.Add(new GameObject(node.rootPoint, false));
            }

            foreach (GameObject go in nodeObjects)
            {

                go.AddNewComponent<MeshRenderer>();
                Effect e = SceneManager.Instance.Content.Load<Effect>("Shaders/PhongBlinnShader");
                go.GetComponent<MeshRenderer>().Material = new DefaultMaterial(e);
                go.GetComponent<MeshRenderer>().Load(ContentModels.Instance.ball, 0.05f);
                go.Transform.Position.Y += 1.5f;
            }

            return nodeObjects;
        }

        public void Draw()
        {
            foreach (GameObject item in sceneNodes)
            {
                item.Draw(SceneManager.Instance.currentScene.GetMainCamera());
            }
        }

        void AddNeighbourToNode(int nodeID, int neighbour)
        {
            nodes[nodeID - 1].addNeighbour(nodes[neighbour - 1]);
        }

    }
}
