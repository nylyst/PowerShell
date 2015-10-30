/**
 * LookupService.cs
 *
 * Copyright (C) 2008 MaxMind Inc.  All Rights Reserved.
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */


using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Collections;

namespace SushiHangover.GeoIP
{

    public static class RegionName
    {

        private static Hashtable GEOIP_REGION_NAME;

        public static String getRegionName(String ccode, String region)
        {
            if (GEOIP_REGION_NAME == null)
            {
                init_region_names();
            }

            if (region == null || region == "00")
            {
                return null;
            }

            if (!GEOIP_REGION_NAME.ContainsKey(ccode))
            {
                return null;
            }

            return (String)((Hashtable)GEOIP_REGION_NAME[ccode])[region];
        }

        private static void init_region_names()
        {

            GEOIP_REGION_NAME = new Hashtable();
            Hashtable cc_reg_AD = new Hashtable();
            cc_reg_AD.Add("02", "Canillo");
            cc_reg_AD.Add("03", "Encamp");
            cc_reg_AD.Add("04", "La Massana");
            cc_reg_AD.Add("05", "Ordino");
            cc_reg_AD.Add("06", "Sant Julia de Loria");
            cc_reg_AD.Add("07", "Andorra la Vella");
            cc_reg_AD.Add("08", "Escaldes-Engordany");
            GEOIP_REGION_NAME.Add("AD", cc_reg_AD);
            Hashtable cc_reg_AE = new Hashtable();
            cc_reg_AE.Add("01", "Abu Dhabi");
            cc_reg_AE.Add("02", "Ajman");
            cc_reg_AE.Add("03", "Dubai");
            cc_reg_AE.Add("04", "Fujairah");
            cc_reg_AE.Add("05", "Ras Al Khaimah");
            cc_reg_AE.Add("06", "Sharjah");
            cc_reg_AE.Add("07", "Umm Al Quwain");
            GEOIP_REGION_NAME.Add("AE", cc_reg_AE);
            Hashtable cc_reg_AF = new Hashtable();
            cc_reg_AF.Add("01", "Badakhshan");
            cc_reg_AF.Add("02", "Badghis");
            cc_reg_AF.Add("03", "Baghlan");
            cc_reg_AF.Add("05", "Bamian");
            cc_reg_AF.Add("06", "Farah");
            cc_reg_AF.Add("07", "Faryab");
            cc_reg_AF.Add("08", "Ghazni");
            cc_reg_AF.Add("09", "Ghowr");
            cc_reg_AF.Add("10", "Helmand");
            cc_reg_AF.Add("11", "Herat");
            cc_reg_AF.Add("13", "Kabol");
            cc_reg_AF.Add("14", "Kapisa");
            cc_reg_AF.Add("17", "Lowgar");
            cc_reg_AF.Add("18", "Nangarhar");
            cc_reg_AF.Add("19", "Nimruz");
            cc_reg_AF.Add("23", "Kandahar");
            cc_reg_AF.Add("24", "Kondoz");
            cc_reg_AF.Add("26", "Takhar");
            cc_reg_AF.Add("27", "Vardak");
            cc_reg_AF.Add("28", "Zabol");
            cc_reg_AF.Add("29", "Paktika");
            cc_reg_AF.Add("30", "Balkh");
            cc_reg_AF.Add("31", "Jowzjan");
            cc_reg_AF.Add("32", "Samangan");
            cc_reg_AF.Add("33", "Sar-e Pol");
            cc_reg_AF.Add("34", "Konar");
            cc_reg_AF.Add("35", "Laghman");
            cc_reg_AF.Add("36", "Paktia");
            cc_reg_AF.Add("37", "Khowst");
            cc_reg_AF.Add("38", "Nurestan");
            cc_reg_AF.Add("39", "Oruzgan");
            cc_reg_AF.Add("40", "Parvan");
            cc_reg_AF.Add("41", "Daykondi");
            cc_reg_AF.Add("42", "Panjshir");
            GEOIP_REGION_NAME.Add("AF", cc_reg_AF);
            Hashtable cc_reg_AG = new Hashtable();
            cc_reg_AG.Add("01", "Barbuda");
            cc_reg_AG.Add("03", "Saint George");
            cc_reg_AG.Add("04", "Saint John");
            cc_reg_AG.Add("05", "Saint Mary");
            cc_reg_AG.Add("06", "Saint Paul");
            cc_reg_AG.Add("07", "Saint Peter");
            cc_reg_AG.Add("08", "Saint Philip");
            cc_reg_AG.Add("09", "Redonda");
            GEOIP_REGION_NAME.Add("AG", cc_reg_AG);
            Hashtable cc_reg_AL = new Hashtable();
            cc_reg_AL.Add("40", "Berat");
            cc_reg_AL.Add("41", "Diber");
            cc_reg_AL.Add("42", "Durres");
            cc_reg_AL.Add("43", "Elbasan");
            cc_reg_AL.Add("44", "Fier");
            cc_reg_AL.Add("45", "Gjirokaster");
            cc_reg_AL.Add("46", "Korce");
            cc_reg_AL.Add("47", "Kukes");
            cc_reg_AL.Add("48", "Lezhe");
            cc_reg_AL.Add("49", "Shkoder");
            cc_reg_AL.Add("50", "Tirane");
            cc_reg_AL.Add("51", "Vlore");
            GEOIP_REGION_NAME.Add("AL", cc_reg_AL);
            Hashtable cc_reg_AM = new Hashtable();
            cc_reg_AM.Add("01", "Aragatsotn");
            cc_reg_AM.Add("02", "Ararat");
            cc_reg_AM.Add("03", "Armavir");
            cc_reg_AM.Add("04", "Geghark'unik'");
            cc_reg_AM.Add("05", "Kotayk'");
            cc_reg_AM.Add("06", "Lorri");
            cc_reg_AM.Add("07", "Shirak");
            cc_reg_AM.Add("08", "Syunik'");
            cc_reg_AM.Add("09", "Tavush");
            cc_reg_AM.Add("10", "Vayots' Dzor");
            cc_reg_AM.Add("11", "Yerevan");
            GEOIP_REGION_NAME.Add("AM", cc_reg_AM);
            Hashtable cc_reg_AO = new Hashtable();
            cc_reg_AO.Add("01", "Benguela");
            cc_reg_AO.Add("02", "Bie");
            cc_reg_AO.Add("03", "Cabinda");
            cc_reg_AO.Add("04", "Cuando Cubango");
            cc_reg_AO.Add("05", "Cuanza Norte");
            cc_reg_AO.Add("06", "Cuanza Sul");
            cc_reg_AO.Add("07", "Cunene");
            cc_reg_AO.Add("08", "Huambo");
            cc_reg_AO.Add("09", "Huila");
            cc_reg_AO.Add("12", "Malanje");
            cc_reg_AO.Add("13", "Namibe");
            cc_reg_AO.Add("14", "Moxico");
            cc_reg_AO.Add("15", "Uige");
            cc_reg_AO.Add("16", "Zaire");
            cc_reg_AO.Add("17", "Lunda Norte");
            cc_reg_AO.Add("18", "Lunda Sul");
            cc_reg_AO.Add("19", "Bengo");
            cc_reg_AO.Add("20", "Luanda");
            GEOIP_REGION_NAME.Add("AO", cc_reg_AO);
            Hashtable cc_reg_AR = new Hashtable();
            cc_reg_AR.Add("01", "Buenos Aires");
            cc_reg_AR.Add("02", "Catamarca");
            cc_reg_AR.Add("03", "Chaco");
            cc_reg_AR.Add("04", "Chubut");
            cc_reg_AR.Add("05", "Cordoba");
            cc_reg_AR.Add("06", "Corrientes");
            cc_reg_AR.Add("07", "Distrito Federal");
            cc_reg_AR.Add("08", "Entre Rios");
            cc_reg_AR.Add("09", "Formosa");
            cc_reg_AR.Add("10", "Jujuy");
            cc_reg_AR.Add("11", "La Pampa");
            cc_reg_AR.Add("12", "La Rioja");
            cc_reg_AR.Add("13", "Mendoza");
            cc_reg_AR.Add("14", "Misiones");
            cc_reg_AR.Add("15", "Neuquen");
            cc_reg_AR.Add("16", "Rio Negro");
            cc_reg_AR.Add("17", "Salta");
            cc_reg_AR.Add("18", "San Juan");
            cc_reg_AR.Add("19", "San Luis");
            cc_reg_AR.Add("20", "Santa Cruz");
            cc_reg_AR.Add("21", "Santa Fe");
            cc_reg_AR.Add("22", "Santiago del Estero");
            cc_reg_AR.Add("23", "Tierra del Fuego");
            cc_reg_AR.Add("24", "Tucuman");
            GEOIP_REGION_NAME.Add("AR", cc_reg_AR);
            Hashtable cc_reg_AT = new Hashtable();
            cc_reg_AT.Add("01", "Burgenland");
            cc_reg_AT.Add("02", "Karnten");
            cc_reg_AT.Add("03", "Niederosterreich");
            cc_reg_AT.Add("04", "Oberosterreich");
            cc_reg_AT.Add("05", "Salzburg");
            cc_reg_AT.Add("06", "Steiermark");
            cc_reg_AT.Add("07", "Tirol");
            cc_reg_AT.Add("08", "Vorarlberg");
            cc_reg_AT.Add("09", "Wien");
            GEOIP_REGION_NAME.Add("AT", cc_reg_AT);
            Hashtable cc_reg_AU = new Hashtable();
            cc_reg_AU.Add("01", "Australian Capital Territory");
            cc_reg_AU.Add("02", "New South Wales");
            cc_reg_AU.Add("03", "Northern Territory");
            cc_reg_AU.Add("04", "Queensland");
            cc_reg_AU.Add("05", "South Australia");
            cc_reg_AU.Add("06", "Tasmania");
            cc_reg_AU.Add("07", "Victoria");
            cc_reg_AU.Add("08", "Western Australia");
            GEOIP_REGION_NAME.Add("AU", cc_reg_AU);
            Hashtable cc_reg_AZ = new Hashtable();
            cc_reg_AZ.Add("01", "Abseron");
            cc_reg_AZ.Add("02", "Agcabadi");
            cc_reg_AZ.Add("03", "Agdam");
            cc_reg_AZ.Add("04", "Agdas");
            cc_reg_AZ.Add("05", "Agstafa");
            cc_reg_AZ.Add("06", "Agsu");
            cc_reg_AZ.Add("07", "Ali Bayramli");
            cc_reg_AZ.Add("08", "Astara");
            cc_reg_AZ.Add("09", "Baki");
            cc_reg_AZ.Add("10", "Balakan");
            cc_reg_AZ.Add("11", "Barda");
            cc_reg_AZ.Add("12", "Beylaqan");
            cc_reg_AZ.Add("13", "Bilasuvar");
            cc_reg_AZ.Add("14", "Cabrayil");
            cc_reg_AZ.Add("15", "Calilabad");
            cc_reg_AZ.Add("16", "Daskasan");
            cc_reg_AZ.Add("17", "Davaci");
            cc_reg_AZ.Add("18", "Fuzuli");
            cc_reg_AZ.Add("19", "Gadabay");
            cc_reg_AZ.Add("20", "Ganca");
            cc_reg_AZ.Add("21", "Goranboy");
            cc_reg_AZ.Add("22", "Goycay");
            cc_reg_AZ.Add("23", "Haciqabul");
            cc_reg_AZ.Add("24", "Imisli");
            cc_reg_AZ.Add("25", "Ismayilli");
            cc_reg_AZ.Add("26", "Kalbacar");
            cc_reg_AZ.Add("27", "Kurdamir");
            cc_reg_AZ.Add("28", "Lacin");
            cc_reg_AZ.Add("29", "Lankaran");
            cc_reg_AZ.Add("30", "Lankaran");
            cc_reg_AZ.Add("31", "Lerik");
            cc_reg_AZ.Add("32", "Masalli");
            cc_reg_AZ.Add("33", "Mingacevir");
            cc_reg_AZ.Add("34", "Naftalan");
            cc_reg_AZ.Add("35", "Naxcivan");
            cc_reg_AZ.Add("36", "Neftcala");
            cc_reg_AZ.Add("37", "Oguz");
            cc_reg_AZ.Add("38", "Qabala");
            cc_reg_AZ.Add("39", "Qax");
            cc_reg_AZ.Add("40", "Qazax");
            cc_reg_AZ.Add("41", "Qobustan");
            cc_reg_AZ.Add("42", "Quba");
            cc_reg_AZ.Add("43", "Qubadli");
            cc_reg_AZ.Add("44", "Qusar");
            cc_reg_AZ.Add("45", "Saatli");
            cc_reg_AZ.Add("46", "Sabirabad");
            cc_reg_AZ.Add("47", "Saki");
            cc_reg_AZ.Add("48", "Saki");
            cc_reg_AZ.Add("49", "Salyan");
            cc_reg_AZ.Add("50", "Samaxi");
            cc_reg_AZ.Add("51", "Samkir");
            cc_reg_AZ.Add("52", "Samux");
            cc_reg_AZ.Add("53", "Siyazan");
            cc_reg_AZ.Add("54", "Sumqayit");
            cc_reg_AZ.Add("55", "Susa");
            cc_reg_AZ.Add("56", "Susa");
            cc_reg_AZ.Add("57", "Tartar");
            cc_reg_AZ.Add("58", "Tovuz");
            cc_reg_AZ.Add("59", "Ucar");
            cc_reg_AZ.Add("60", "Xacmaz");
            cc_reg_AZ.Add("61", "Xankandi");
            cc_reg_AZ.Add("62", "Xanlar");
            cc_reg_AZ.Add("63", "Xizi");
            cc_reg_AZ.Add("64", "Xocali");
            cc_reg_AZ.Add("65", "Xocavand");
            cc_reg_AZ.Add("66", "Yardimli");
            cc_reg_AZ.Add("67", "Yevlax");
            cc_reg_AZ.Add("68", "Yevlax");
            cc_reg_AZ.Add("69", "Zangilan");
            cc_reg_AZ.Add("70", "Zaqatala");
            cc_reg_AZ.Add("71", "Zardab");
            GEOIP_REGION_NAME.Add("AZ", cc_reg_AZ);
            Hashtable cc_reg_BA = new Hashtable();
            cc_reg_BA.Add("01", "Federation of Bosnia and Herzegovina");
            cc_reg_BA.Add("02", "Republika Srpska");
            GEOIP_REGION_NAME.Add("BA", cc_reg_BA);
            Hashtable cc_reg_BB = new Hashtable();
            cc_reg_BB.Add("01", "Christ Church");
            cc_reg_BB.Add("02", "Saint Andrew");
            cc_reg_BB.Add("03", "Saint George");
            cc_reg_BB.Add("04", "Saint James");
            cc_reg_BB.Add("05", "Saint John");
            cc_reg_BB.Add("06", "Saint Joseph");
            cc_reg_BB.Add("07", "Saint Lucy");
            cc_reg_BB.Add("08", "Saint Michael");
            cc_reg_BB.Add("09", "Saint Peter");
            cc_reg_BB.Add("10", "Saint Philip");
            cc_reg_BB.Add("11", "Saint Thomas");
            GEOIP_REGION_NAME.Add("BB", cc_reg_BB);
            Hashtable cc_reg_BD = new Hashtable();
            cc_reg_BD.Add("81", "Dhaka");
            cc_reg_BD.Add("82", "Khulna");
            cc_reg_BD.Add("83", "Rajshahi");
            cc_reg_BD.Add("84", "Chittagong");
            cc_reg_BD.Add("85", "Barisal");
            cc_reg_BD.Add("86", "Sylhet");
            GEOIP_REGION_NAME.Add("BD", cc_reg_BD);
            Hashtable cc_reg_BE = new Hashtable();
            cc_reg_BE.Add("01", "Antwerpen");
            cc_reg_BE.Add("03", "Hainaut");
            cc_reg_BE.Add("04", "Liege");
            cc_reg_BE.Add("05", "Limburg");
            cc_reg_BE.Add("06", "Luxembourg");
            cc_reg_BE.Add("07", "Namur");
            cc_reg_BE.Add("08", "Oost-Vlaanderen");
            cc_reg_BE.Add("09", "West-Vlaanderen");
            cc_reg_BE.Add("10", "Brabant Wallon");
            cc_reg_BE.Add("11", "Brussels Hoofdstedelijk Gewest");
            cc_reg_BE.Add("12", "Vlaams-Brabant");
            cc_reg_BE.Add("13", "Flanders");
            cc_reg_BE.Add("14", "Wallonia");
            GEOIP_REGION_NAME.Add("BE", cc_reg_BE);
            Hashtable cc_reg_BF = new Hashtable();
            cc_reg_BF.Add("15", "Bam");
            cc_reg_BF.Add("19", "Boulkiemde");
            cc_reg_BF.Add("20", "Ganzourgou");
            cc_reg_BF.Add("21", "Gnagna");
            cc_reg_BF.Add("28", "Kouritenga");
            cc_reg_BF.Add("33", "Oudalan");
            cc_reg_BF.Add("34", "Passore");
            cc_reg_BF.Add("36", "Sanguie");
            cc_reg_BF.Add("40", "Soum");
            cc_reg_BF.Add("42", "Tapoa");
            cc_reg_BF.Add("44", "Zoundweogo");
            cc_reg_BF.Add("45", "Bale");
            cc_reg_BF.Add("46", "Banwa");
            cc_reg_BF.Add("47", "Bazega");
            cc_reg_BF.Add("48", "Bougouriba");
            cc_reg_BF.Add("49", "Boulgou");
            cc_reg_BF.Add("50", "Gourma");
            cc_reg_BF.Add("51", "Houet");
            cc_reg_BF.Add("52", "Ioba");
            cc_reg_BF.Add("53", "Kadiogo");
            cc_reg_BF.Add("54", "Kenedougou");
            cc_reg_BF.Add("55", "Komoe");
            cc_reg_BF.Add("56", "Komondjari");
            cc_reg_BF.Add("57", "Kompienga");
            cc_reg_BF.Add("58", "Kossi");
            cc_reg_BF.Add("59", "Koulpelogo");
            cc_reg_BF.Add("60", "Kourweogo");
            cc_reg_BF.Add("61", "Leraba");
            cc_reg_BF.Add("62", "Loroum");
            cc_reg_BF.Add("63", "Mouhoun");
            cc_reg_BF.Add("64", "Namentenga");
            cc_reg_BF.Add("65", "Naouri");
            cc_reg_BF.Add("66", "Nayala");
            cc_reg_BF.Add("67", "Noumbiel");
            cc_reg_BF.Add("68", "Oubritenga");
            cc_reg_BF.Add("69", "Poni");
            cc_reg_BF.Add("70", "Sanmatenga");
            cc_reg_BF.Add("71", "Seno");
            cc_reg_BF.Add("72", "Sissili");
            cc_reg_BF.Add("73", "Sourou");
            cc_reg_BF.Add("74", "Tuy");
            cc_reg_BF.Add("75", "Yagha");
            cc_reg_BF.Add("76", "Yatenga");
            cc_reg_BF.Add("77", "Ziro");
            cc_reg_BF.Add("78", "Zondoma");
            GEOIP_REGION_NAME.Add("BF", cc_reg_BF);
            Hashtable cc_reg_BG = new Hashtable();
            cc_reg_BG.Add("33", "Mikhaylovgrad");
            cc_reg_BG.Add("38", "Blagoevgrad");
            cc_reg_BG.Add("39", "Burgas");
            cc_reg_BG.Add("40", "Dobrich");
            cc_reg_BG.Add("41", "Gabrovo");
            cc_reg_BG.Add("42", "Grad Sofiya");
            cc_reg_BG.Add("43", "Khaskovo");
            cc_reg_BG.Add("44", "Kurdzhali");
            cc_reg_BG.Add("45", "Kyustendil");
            cc_reg_BG.Add("46", "Lovech");
            cc_reg_BG.Add("47", "Montana");
            cc_reg_BG.Add("48", "Pazardzhik");
            cc_reg_BG.Add("49", "Pernik");
            cc_reg_BG.Add("50", "Pleven");
            cc_reg_BG.Add("51", "Plovdiv");
            cc_reg_BG.Add("52", "Razgrad");
            cc_reg_BG.Add("53", "Ruse");
            cc_reg_BG.Add("54", "Shumen");
            cc_reg_BG.Add("55", "Silistra");
            cc_reg_BG.Add("56", "Sliven");
            cc_reg_BG.Add("57", "Smolyan");
            cc_reg_BG.Add("58", "Sofiya");
            cc_reg_BG.Add("59", "Stara Zagora");
            cc_reg_BG.Add("60", "Turgovishte");
            cc_reg_BG.Add("61", "Varna");
            cc_reg_BG.Add("62", "Veliko Turnovo");
            cc_reg_BG.Add("63", "Vidin");
            cc_reg_BG.Add("64", "Vratsa");
            cc_reg_BG.Add("65", "Yambol");
            GEOIP_REGION_NAME.Add("BG", cc_reg_BG);
            Hashtable cc_reg_BH = new Hashtable();
            cc_reg_BH.Add("01", "Al Hadd");
            cc_reg_BH.Add("02", "Al Manamah");
            cc_reg_BH.Add("05", "Jidd Hafs");
            cc_reg_BH.Add("06", "Sitrah");
            cc_reg_BH.Add("08", "Al Mintaqah al Gharbiyah");
            cc_reg_BH.Add("09", "Mintaqat Juzur Hawar");
            cc_reg_BH.Add("10", "Al Mintaqah ash Shamaliyah");
            cc_reg_BH.Add("11", "Al Mintaqah al Wusta");
            cc_reg_BH.Add("12", "Madinat");
            cc_reg_BH.Add("13", "Ar Rifa");
            cc_reg_BH.Add("14", "Madinat Hamad");
            cc_reg_BH.Add("15", "Al Muharraq");
            cc_reg_BH.Add("16", "Al Asimah");
            cc_reg_BH.Add("17", "Al Janubiyah");
            cc_reg_BH.Add("18", "Ash Shamaliyah");
            cc_reg_BH.Add("19", "Al Wusta");
            GEOIP_REGION_NAME.Add("BH", cc_reg_BH);
            Hashtable cc_reg_BI = new Hashtable();
            cc_reg_BI.Add("02", "Bujumbura");
            cc_reg_BI.Add("09", "Bubanza");
            cc_reg_BI.Add("10", "Bururi");
            cc_reg_BI.Add("11", "Cankuzo");
            cc_reg_BI.Add("12", "Cibitoke");
            cc_reg_BI.Add("13", "Gitega");
            cc_reg_BI.Add("14", "Karuzi");
            cc_reg_BI.Add("15", "Kayanza");
            cc_reg_BI.Add("16", "Kirundo");
            cc_reg_BI.Add("17", "Makamba");
            cc_reg_BI.Add("18", "Muyinga");
            cc_reg_BI.Add("19", "Ngozi");
            cc_reg_BI.Add("20", "Rutana");
            cc_reg_BI.Add("21", "Ruyigi");
            cc_reg_BI.Add("22", "Muramvya");
            cc_reg_BI.Add("23", "Mwaro");
            GEOIP_REGION_NAME.Add("BI", cc_reg_BI);
            Hashtable cc_reg_BJ = new Hashtable();
            cc_reg_BJ.Add("07", "Alibori");
            cc_reg_BJ.Add("08", "Atakora");
            cc_reg_BJ.Add("09", "Atlanyique");
            cc_reg_BJ.Add("10", "Borgou");
            cc_reg_BJ.Add("11", "Collines");
            cc_reg_BJ.Add("12", "Kouffo");
            cc_reg_BJ.Add("13", "Donga");
            cc_reg_BJ.Add("14", "Littoral");
            cc_reg_BJ.Add("15", "Mono");
            cc_reg_BJ.Add("16", "Oueme");
            cc_reg_BJ.Add("17", "Plateau");
            cc_reg_BJ.Add("18", "Zou");
            GEOIP_REGION_NAME.Add("BJ", cc_reg_BJ);
            Hashtable cc_reg_BM = new Hashtable();
            cc_reg_BM.Add("01", "Devonshire");
            cc_reg_BM.Add("02", "Hamilton");
            cc_reg_BM.Add("03", "Hamilton");
            cc_reg_BM.Add("04", "Paget");
            cc_reg_BM.Add("05", "Pembroke");
            cc_reg_BM.Add("06", "Saint George");
            cc_reg_BM.Add("07", "Saint George's");
            cc_reg_BM.Add("08", "Sandys");
            cc_reg_BM.Add("09", "Smiths");
            cc_reg_BM.Add("10", "Southampton");
            cc_reg_BM.Add("11", "Warwick");
            GEOIP_REGION_NAME.Add("BM", cc_reg_BM);
            Hashtable cc_reg_BN = new Hashtable();
            cc_reg_BN.Add("07", "Alibori");
            cc_reg_BN.Add("08", "Belait");
            cc_reg_BN.Add("09", "Brunei and Muara");
            cc_reg_BN.Add("10", "Temburong");
            cc_reg_BN.Add("11", "Collines");
            cc_reg_BN.Add("12", "Kouffo");
            cc_reg_BN.Add("13", "Donga");
            cc_reg_BN.Add("14", "Littoral");
            cc_reg_BN.Add("15", "Tutong");
            cc_reg_BN.Add("16", "Oueme");
            cc_reg_BN.Add("17", "Plateau");
            cc_reg_BN.Add("18", "Zou");
            GEOIP_REGION_NAME.Add("BN", cc_reg_BN);
            Hashtable cc_reg_BO = new Hashtable();
            cc_reg_BO.Add("01", "Chuquisaca");
            cc_reg_BO.Add("02", "Cochabamba");
            cc_reg_BO.Add("03", "El Beni");
            cc_reg_BO.Add("04", "La Paz");
            cc_reg_BO.Add("05", "Oruro");
            cc_reg_BO.Add("06", "Pando");
            cc_reg_BO.Add("07", "Potosi");
            cc_reg_BO.Add("08", "Santa Cruz");
            cc_reg_BO.Add("09", "Tarija");
            GEOIP_REGION_NAME.Add("BO", cc_reg_BO);
            Hashtable cc_reg_BR = new Hashtable();
            cc_reg_BR.Add("01", "Acre");
            cc_reg_BR.Add("02", "Alagoas");
            cc_reg_BR.Add("03", "Amapa");
            cc_reg_BR.Add("04", "Amazonas");
            cc_reg_BR.Add("05", "Bahia");
            cc_reg_BR.Add("06", "Ceara");
            cc_reg_BR.Add("07", "Distrito Federal");
            cc_reg_BR.Add("08", "Espirito Santo");
            cc_reg_BR.Add("11", "Mato Grosso do Sul");
            cc_reg_BR.Add("13", "Maranhao");
            cc_reg_BR.Add("14", "Mato Grosso");
            cc_reg_BR.Add("15", "Minas Gerais");
            cc_reg_BR.Add("16", "Para");
            cc_reg_BR.Add("17", "Paraiba");
            cc_reg_BR.Add("18", "Parana");
            cc_reg_BR.Add("20", "Piaui");
            cc_reg_BR.Add("21", "Rio de Janeiro");
            cc_reg_BR.Add("22", "Rio Grande do Norte");
            cc_reg_BR.Add("23", "Rio Grande do Sul");
            cc_reg_BR.Add("24", "Rondonia");
            cc_reg_BR.Add("25", "Roraima");
            cc_reg_BR.Add("26", "Santa Catarina");
            cc_reg_BR.Add("27", "Sao Paulo");
            cc_reg_BR.Add("28", "Sergipe");
            cc_reg_BR.Add("29", "Goias");
            cc_reg_BR.Add("30", "Pernambuco");
            cc_reg_BR.Add("31", "Tocantins");
            GEOIP_REGION_NAME.Add("BR", cc_reg_BR);
            Hashtable cc_reg_BS = new Hashtable();
            cc_reg_BS.Add("05", "Bimini");
            cc_reg_BS.Add("06", "Cat Island");
            cc_reg_BS.Add("10", "Exuma");
            cc_reg_BS.Add("13", "Inagua");
            cc_reg_BS.Add("15", "Long Island");
            cc_reg_BS.Add("16", "Mayaguana");
            cc_reg_BS.Add("18", "Ragged Island");
            cc_reg_BS.Add("22", "Harbour Island");
            cc_reg_BS.Add("23", "New Providence");
            cc_reg_BS.Add("24", "Acklins and Crooked Islands");
            cc_reg_BS.Add("25", "Freeport");
            cc_reg_BS.Add("26", "Fresh Creek");
            cc_reg_BS.Add("27", "Governor's Harbour");
            cc_reg_BS.Add("28", "Green Turtle Cay");
            cc_reg_BS.Add("29", "High Rock");
            cc_reg_BS.Add("30", "Kemps Bay");
            cc_reg_BS.Add("31", "Marsh Harbour");
            cc_reg_BS.Add("32", "Nichollstown and Berry Islands");
            cc_reg_BS.Add("33", "Rock Sound");
            cc_reg_BS.Add("34", "Sandy Point");
            cc_reg_BS.Add("35", "San Salvador and Rum Cay");
            GEOIP_REGION_NAME.Add("BS", cc_reg_BS);
            Hashtable cc_reg_BT = new Hashtable();
            cc_reg_BT.Add("05", "Bumthang");
            cc_reg_BT.Add("06", "Chhukha");
            cc_reg_BT.Add("07", "Chirang");
            cc_reg_BT.Add("08", "Daga");
            cc_reg_BT.Add("09", "Geylegphug");
            cc_reg_BT.Add("10", "Ha");
            cc_reg_BT.Add("11", "Lhuntshi");
            cc_reg_BT.Add("12", "Mongar");
            cc_reg_BT.Add("13", "Paro");
            cc_reg_BT.Add("14", "Pemagatsel");
            cc_reg_BT.Add("15", "Punakha");
            cc_reg_BT.Add("16", "Samchi");
            cc_reg_BT.Add("17", "Samdrup");
            cc_reg_BT.Add("18", "Shemgang");
            cc_reg_BT.Add("19", "Tashigang");
            cc_reg_BT.Add("20", "Thimphu");
            cc_reg_BT.Add("21", "Tongsa");
            cc_reg_BT.Add("22", "Wangdi Phodrang");
            GEOIP_REGION_NAME.Add("BT", cc_reg_BT);
            Hashtable cc_reg_BW = new Hashtable();
            cc_reg_BW.Add("01", "Central");
            cc_reg_BW.Add("03", "Ghanzi");
            cc_reg_BW.Add("04", "Kgalagadi");
            cc_reg_BW.Add("05", "Kgatleng");
            cc_reg_BW.Add("06", "Kweneng");
            cc_reg_BW.Add("08", "North-East");
            cc_reg_BW.Add("09", "South-East");
            cc_reg_BW.Add("10", "Southern");
            cc_reg_BW.Add("11", "North-West");
            GEOIP_REGION_NAME.Add("BW", cc_reg_BW);
            Hashtable cc_reg_BY = new Hashtable();
            cc_reg_BY.Add("01", "Brestskaya Voblasts'");
            cc_reg_BY.Add("02", "Homyel'skaya Voblasts'");
            cc_reg_BY.Add("03", "Hrodzyenskaya Voblasts'");
            cc_reg_BY.Add("04", "Minsk");
            cc_reg_BY.Add("05", "Minskaya Voblasts'");
            cc_reg_BY.Add("06", "Mahilyowskaya Voblasts'");
            cc_reg_BY.Add("07", "Vitsyebskaya Voblasts'");
            GEOIP_REGION_NAME.Add("BY", cc_reg_BY);
            Hashtable cc_reg_BZ = new Hashtable();
            cc_reg_BZ.Add("01", "Belize");
            cc_reg_BZ.Add("02", "Cayo");
            cc_reg_BZ.Add("03", "Corozal");
            cc_reg_BZ.Add("04", "Orange Walk");
            cc_reg_BZ.Add("05", "Stann Creek");
            cc_reg_BZ.Add("06", "Toledo");
            GEOIP_REGION_NAME.Add("BZ", cc_reg_BZ);
            Hashtable cc_reg_CA = new Hashtable();
            cc_reg_CA.Add("AB", "Alberta");
            cc_reg_CA.Add("BC", "British Columbia");
            cc_reg_CA.Add("MB", "Manitoba");
            cc_reg_CA.Add("NB", "New Brunswick");
            cc_reg_CA.Add("NL", "Newfoundland");
            cc_reg_CA.Add("NS", "Nova Scotia");
            cc_reg_CA.Add("NT", "Northwest Territories");
            cc_reg_CA.Add("NU", "Nunavut");
            cc_reg_CA.Add("ON", "Ontario");
            cc_reg_CA.Add("PE", "Prince Edward Island");
            cc_reg_CA.Add("QC", "Quebec");
            cc_reg_CA.Add("SK", "Saskatchewan");
            cc_reg_CA.Add("YT", "Yukon Territory");
            GEOIP_REGION_NAME.Add("CA", cc_reg_CA);
            Hashtable cc_reg_CD = new Hashtable();
            cc_reg_CD.Add("01", "Bandundu");
            cc_reg_CD.Add("02", "Equateur");
            cc_reg_CD.Add("04", "Kasai-Oriental");
            cc_reg_CD.Add("05", "Katanga");
            cc_reg_CD.Add("06", "Kinshasa");
            cc_reg_CD.Add("08", "Bas-Congo");
            cc_reg_CD.Add("09", "Orientale");
            cc_reg_CD.Add("10", "Maniema");
            cc_reg_CD.Add("11", "Nord-Kivu");
            cc_reg_CD.Add("12", "Sud-Kivu");
            GEOIP_REGION_NAME.Add("CD", cc_reg_CD);
            Hashtable cc_reg_CF = new Hashtable();
            cc_reg_CF.Add("01", "Bamingui-Bangoran");
            cc_reg_CF.Add("02", "Basse-Kotto");
            cc_reg_CF.Add("03", "Haute-Kotto");
            cc_reg_CF.Add("04", "Mambere-Kadei");
            cc_reg_CF.Add("05", "Haut-Mbomou");
            cc_reg_CF.Add("06", "Kemo");
            cc_reg_CF.Add("07", "Lobaye");
            cc_reg_CF.Add("08", "Mbomou");
            cc_reg_CF.Add("09", "Nana-Mambere");
            cc_reg_CF.Add("11", "Ouaka");
            cc_reg_CF.Add("12", "Ouham");
            cc_reg_CF.Add("13", "Ouham-Pende");
            cc_reg_CF.Add("14", "Cuvette-Ouest");
            cc_reg_CF.Add("15", "Nana-Grebizi");
            cc_reg_CF.Add("16", "Sangha-Mbaere");
            cc_reg_CF.Add("17", "Ombella-Mpoko");
            cc_reg_CF.Add("18", "Bangui");
            GEOIP_REGION_NAME.Add("CF", cc_reg_CF);
            Hashtable cc_reg_CG = new Hashtable();
            cc_reg_CG.Add("01", "Bouenza");
            cc_reg_CG.Add("04", "Kouilou");
            cc_reg_CG.Add("05", "Lekoumou");
            cc_reg_CG.Add("06", "Likouala");
            cc_reg_CG.Add("07", "Niari");
            cc_reg_CG.Add("08", "Plateaux");
            cc_reg_CG.Add("10", "Sangha");
            cc_reg_CG.Add("11", "Pool");
            cc_reg_CG.Add("12", "Brazzaville");
            cc_reg_CG.Add("13", "Cuvette");
            cc_reg_CG.Add("14", "Cuvette-Ouest");
            GEOIP_REGION_NAME.Add("CG", cc_reg_CG);
            Hashtable cc_reg_CH = new Hashtable();
            cc_reg_CH.Add("01", "Aargau");
            cc_reg_CH.Add("02", "Ausser-Rhoden");
            cc_reg_CH.Add("03", "Basel-Landschaft");
            cc_reg_CH.Add("04", "Basel-Stadt");
            cc_reg_CH.Add("05", "Bern");
            cc_reg_CH.Add("06", "Fribourg");
            cc_reg_CH.Add("07", "Geneve");
            cc_reg_CH.Add("08", "Glarus");
            cc_reg_CH.Add("09", "Graubunden");
            cc_reg_CH.Add("10", "Inner-Rhoden");
            cc_reg_CH.Add("11", "Luzern");
            cc_reg_CH.Add("12", "Neuchatel");
            cc_reg_CH.Add("13", "Nidwalden");
            cc_reg_CH.Add("14", "Obwalden");
            cc_reg_CH.Add("15", "Sankt Gallen");
            cc_reg_CH.Add("16", "Schaffhausen");
            cc_reg_CH.Add("17", "Schwyz");
            cc_reg_CH.Add("18", "Solothurn");
            cc_reg_CH.Add("19", "Thurgau");
            cc_reg_CH.Add("20", "Ticino");
            cc_reg_CH.Add("21", "Uri");
            cc_reg_CH.Add("22", "Valais");
            cc_reg_CH.Add("23", "Vaud");
            cc_reg_CH.Add("24", "Zug");
            cc_reg_CH.Add("25", "Zurich");
            cc_reg_CH.Add("26", "Jura");
            GEOIP_REGION_NAME.Add("CH", cc_reg_CH);
            Hashtable cc_reg_CI = new Hashtable();
            cc_reg_CI.Add("74", "Agneby");
            cc_reg_CI.Add("75", "Bafing");
            cc_reg_CI.Add("76", "Bas-Sassandra");
            cc_reg_CI.Add("77", "Denguele");
            cc_reg_CI.Add("78", "Dix-Huit Montagnes");
            cc_reg_CI.Add("79", "Fromager");
            cc_reg_CI.Add("80", "Haut-Sassandra");
            cc_reg_CI.Add("81", "Lacs");
            cc_reg_CI.Add("82", "Lagunes");
            cc_reg_CI.Add("83", "Marahoue");
            cc_reg_CI.Add("84", "Moyen-Cavally");
            cc_reg_CI.Add("85", "Moyen-Comoe");
            cc_reg_CI.Add("86", "N'zi-Comoe");
            cc_reg_CI.Add("87", "Savanes");
            cc_reg_CI.Add("88", "Sud-Bandama");
            cc_reg_CI.Add("89", "Sud-Comoe");
            cc_reg_CI.Add("90", "Vallee du Bandama");
            cc_reg_CI.Add("91", "Worodougou");
            cc_reg_CI.Add("92", "Zanzan");
            GEOIP_REGION_NAME.Add("CI", cc_reg_CI);
            Hashtable cc_reg_CL = new Hashtable();
            cc_reg_CL.Add("01", "Valparaiso");
            cc_reg_CL.Add("02", "Aisen del General Carlos Ibanez del Campo");
            cc_reg_CL.Add("03", "Antofagasta");
            cc_reg_CL.Add("04", "Araucania");
            cc_reg_CL.Add("05", "Atacama");
            cc_reg_CL.Add("06", "Bio-Bio");
            cc_reg_CL.Add("07", "Coquimbo");
            cc_reg_CL.Add("08", "Libertador General Bernardo O'Higgins");
            cc_reg_CL.Add("09", "Los Lagos");
            cc_reg_CL.Add("10", "Magallanes y de la Antartica Chilena");
            cc_reg_CL.Add("11", "Maule");
            cc_reg_CL.Add("12", "Region Metropolitana");
            cc_reg_CL.Add("13", "Tarapaca");
            cc_reg_CL.Add("14", "Los Lagos");
            cc_reg_CL.Add("15", "Tarapaca");
            cc_reg_CL.Add("16", "Arica y Parinacota");
            cc_reg_CL.Add("17", "Los Rios");
            GEOIP_REGION_NAME.Add("CL", cc_reg_CL);
            Hashtable cc_reg_CM = new Hashtable();
            cc_reg_CM.Add("04", "Est");
            cc_reg_CM.Add("05", "Littoral");
            cc_reg_CM.Add("07", "Nord-Ouest");
            cc_reg_CM.Add("08", "Ouest");
            cc_reg_CM.Add("09", "Sud-Ouest");
            cc_reg_CM.Add("10", "Adamaoua");
            cc_reg_CM.Add("11", "Centre");
            cc_reg_CM.Add("12", "Extreme-Nord");
            cc_reg_CM.Add("13", "Nord");
            cc_reg_CM.Add("14", "Sud");
            GEOIP_REGION_NAME.Add("CM", cc_reg_CM);
            Hashtable cc_reg_CN = new Hashtable();
            cc_reg_CN.Add("01", "Anhui");
            cc_reg_CN.Add("02", "Zhejiang");
            cc_reg_CN.Add("03", "Jiangxi");
            cc_reg_CN.Add("04", "Jiangsu");
            cc_reg_CN.Add("05", "Jilin");
            cc_reg_CN.Add("06", "Qinghai");
            cc_reg_CN.Add("07", "Fujian");
            cc_reg_CN.Add("08", "Heilongjiang");
            cc_reg_CN.Add("09", "Henan");
            cc_reg_CN.Add("10", "Hebei");
            cc_reg_CN.Add("11", "Hunan");
            cc_reg_CN.Add("12", "Hubei");
            cc_reg_CN.Add("13", "Xinjiang");
            cc_reg_CN.Add("14", "Xizang");
            cc_reg_CN.Add("15", "Gansu");
            cc_reg_CN.Add("16", "Guangxi");
            cc_reg_CN.Add("18", "Guizhou");
            cc_reg_CN.Add("19", "Liaoning");
            cc_reg_CN.Add("20", "Nei Mongol");
            cc_reg_CN.Add("21", "Ningxia");
            cc_reg_CN.Add("22", "Beijing");
            cc_reg_CN.Add("23", "Shanghai");
            cc_reg_CN.Add("24", "Shanxi");
            cc_reg_CN.Add("25", "Shandong");
            cc_reg_CN.Add("26", "Shaanxi");
            cc_reg_CN.Add("28", "Tianjin");
            cc_reg_CN.Add("29", "Yunnan");
            cc_reg_CN.Add("30", "Guangdong");
            cc_reg_CN.Add("31", "Hainan");
            cc_reg_CN.Add("32", "Sichuan");
            cc_reg_CN.Add("33", "Chongqing");
            GEOIP_REGION_NAME.Add("CN", cc_reg_CN);
            Hashtable cc_reg_CO = new Hashtable();
            cc_reg_CO.Add("01", "Amazonas");
            cc_reg_CO.Add("02", "Antioquia");
            cc_reg_CO.Add("03", "Arauca");
            cc_reg_CO.Add("04", "Atlantico");
            cc_reg_CO.Add("08", "Caqueta");
            cc_reg_CO.Add("09", "Cauca");
            cc_reg_CO.Add("10", "Cesar");
            cc_reg_CO.Add("11", "Choco");
            cc_reg_CO.Add("12", "Cordoba");
            cc_reg_CO.Add("14", "Guaviare");
            cc_reg_CO.Add("15", "Guainia");
            cc_reg_CO.Add("16", "Huila");
            cc_reg_CO.Add("17", "La Guajira");
            cc_reg_CO.Add("19", "Meta");
            cc_reg_CO.Add("20", "Narino");
            cc_reg_CO.Add("21", "Norte de Santander");
            cc_reg_CO.Add("22", "Putumayo");
            cc_reg_CO.Add("23", "Quindio");
            cc_reg_CO.Add("24", "Risaralda");
            cc_reg_CO.Add("25", "San Andres y Providencia");
            cc_reg_CO.Add("26", "Santander");
            cc_reg_CO.Add("27", "Sucre");
            cc_reg_CO.Add("28", "Tolima");
            cc_reg_CO.Add("29", "Valle del Cauca");
            cc_reg_CO.Add("30", "Vaupes");
            cc_reg_CO.Add("31", "Vichada");
            cc_reg_CO.Add("32", "Casanare");
            cc_reg_CO.Add("33", "Cundinamarca");
            cc_reg_CO.Add("34", "Distrito Especial");
            cc_reg_CO.Add("35", "Bolivar");
            cc_reg_CO.Add("36", "Boyaca");
            cc_reg_CO.Add("37", "Caldas");
            cc_reg_CO.Add("38", "Magdalena");
            GEOIP_REGION_NAME.Add("CO", cc_reg_CO);
            Hashtable cc_reg_CR = new Hashtable();
            cc_reg_CR.Add("01", "Alajuela");
            cc_reg_CR.Add("02", "Cartago");
            cc_reg_CR.Add("03", "Guanacaste");
            cc_reg_CR.Add("04", "Heredia");
            cc_reg_CR.Add("06", "Limon");
            cc_reg_CR.Add("07", "Puntarenas");
            cc_reg_CR.Add("08", "San Jose");
            GEOIP_REGION_NAME.Add("CR", cc_reg_CR);
            Hashtable cc_reg_CU = new Hashtable();
            cc_reg_CU.Add("01", "Pinar del Rio");
            cc_reg_CU.Add("02", "Ciudad de la Habana");
            cc_reg_CU.Add("03", "Matanzas");
            cc_reg_CU.Add("04", "Isla de la Juventud");
            cc_reg_CU.Add("05", "Camaguey");
            cc_reg_CU.Add("07", "Ciego de Avila");
            cc_reg_CU.Add("08", "Cienfuegos");
            cc_reg_CU.Add("09", "Granma");
            cc_reg_CU.Add("10", "Guantanamo");
            cc_reg_CU.Add("11", "La Habana");
            cc_reg_CU.Add("12", "Holguin");
            cc_reg_CU.Add("13", "Las Tunas");
            cc_reg_CU.Add("14", "Sancti Spiritus");
            cc_reg_CU.Add("15", "Santiago de Cuba");
            cc_reg_CU.Add("16", "Villa Clara");
            GEOIP_REGION_NAME.Add("CU", cc_reg_CU);
            Hashtable cc_reg_CV = new Hashtable();
            cc_reg_CV.Add("01", "Boa Vista");
            cc_reg_CV.Add("02", "Brava");
            cc_reg_CV.Add("04", "Maio");
            cc_reg_CV.Add("05", "Paul");
            cc_reg_CV.Add("07", "Ribeira Grande");
            cc_reg_CV.Add("08", "Sal");
            cc_reg_CV.Add("10", "Sao Nicolau");
            cc_reg_CV.Add("11", "Sao Vicente");
            cc_reg_CV.Add("13", "Mosteiros");
            cc_reg_CV.Add("14", "Praia");
            cc_reg_CV.Add("15", "Santa Catarina");
            cc_reg_CV.Add("16", "Santa Cruz");
            cc_reg_CV.Add("17", "Sao Domingos");
            cc_reg_CV.Add("18", "Sao Filipe");
            cc_reg_CV.Add("19", "Sao Miguel");
            cc_reg_CV.Add("20", "Tarrafal");
            GEOIP_REGION_NAME.Add("CV", cc_reg_CV);
            Hashtable cc_reg_CY = new Hashtable();
            cc_reg_CY.Add("01", "Famagusta");
            cc_reg_CY.Add("02", "Kyrenia");
            cc_reg_CY.Add("03", "Larnaca");
            cc_reg_CY.Add("04", "Nicosia");
            cc_reg_CY.Add("05", "Limassol");
            cc_reg_CY.Add("06", "Paphos");
            GEOIP_REGION_NAME.Add("CY", cc_reg_CY);
            Hashtable cc_reg_CZ = new Hashtable();
            cc_reg_CZ.Add("52", "Hlavni mesto Praha");
            cc_reg_CZ.Add("78", "Jihomoravsky kraj");
            cc_reg_CZ.Add("79", "Jihocesky kraj");
            cc_reg_CZ.Add("80", "Vysocina");
            cc_reg_CZ.Add("81", "Karlovarsky kraj");
            cc_reg_CZ.Add("82", "Kralovehradecky kraj");
            cc_reg_CZ.Add("83", "Liberecky kraj");
            cc_reg_CZ.Add("84", "Olomoucky kraj");
            cc_reg_CZ.Add("85", "Moravskoslezsky kraj");
            cc_reg_CZ.Add("86", "Pardubicky kraj");
            cc_reg_CZ.Add("87", "Plzensky kraj");
            cc_reg_CZ.Add("88", "Stredocesky kraj");
            cc_reg_CZ.Add("89", "Ustecky kraj");
            cc_reg_CZ.Add("90", "Zlinsky kraj");
            GEOIP_REGION_NAME.Add("CZ", cc_reg_CZ);
            Hashtable cc_reg_DE = new Hashtable();
            cc_reg_DE.Add("01", "Baden-Wurttemberg");
            cc_reg_DE.Add("02", "Bayern");
            cc_reg_DE.Add("03", "Bremen");
            cc_reg_DE.Add("04", "Hamburg");
            cc_reg_DE.Add("05", "Hessen");
            cc_reg_DE.Add("06", "Niedersachsen");
            cc_reg_DE.Add("07", "Nordrhein-Westfalen");
            cc_reg_DE.Add("08", "Rheinland-Pfalz");
            cc_reg_DE.Add("09", "Saarland");
            cc_reg_DE.Add("10", "Schleswig-Holstein");
            cc_reg_DE.Add("11", "Brandenburg");
            cc_reg_DE.Add("12", "Mecklenburg-Vorpommern");
            cc_reg_DE.Add("13", "Sachsen");
            cc_reg_DE.Add("14", "Sachsen-Anhalt");
            cc_reg_DE.Add("15", "Thuringen");
            cc_reg_DE.Add("16", "Berlin");
            GEOIP_REGION_NAME.Add("DE", cc_reg_DE);
            Hashtable cc_reg_DJ = new Hashtable();
            cc_reg_DJ.Add("01", "Ali Sabieh");
            cc_reg_DJ.Add("04", "Obock");
            cc_reg_DJ.Add("05", "Tadjoura");
            cc_reg_DJ.Add("06", "Dikhil");
            cc_reg_DJ.Add("07", "Djibouti");
            cc_reg_DJ.Add("08", "Arta");
            GEOIP_REGION_NAME.Add("DJ", cc_reg_DJ);
            Hashtable cc_reg_DK = new Hashtable();
            cc_reg_DK.Add("17", "Hovedstaden");
            cc_reg_DK.Add("18", "Midtjylland");
            cc_reg_DK.Add("19", "Nordjylland");
            cc_reg_DK.Add("20", "Sjelland");
            cc_reg_DK.Add("21", "Syddanmark");
            GEOIP_REGION_NAME.Add("DK", cc_reg_DK);
            Hashtable cc_reg_DM = new Hashtable();
            cc_reg_DM.Add("02", "Saint Andrew");
            cc_reg_DM.Add("03", "Saint David");
            cc_reg_DM.Add("04", "Saint George");
            cc_reg_DM.Add("05", "Saint John");
            cc_reg_DM.Add("06", "Saint Joseph");
            cc_reg_DM.Add("07", "Saint Luke");
            cc_reg_DM.Add("08", "Saint Mark");
            cc_reg_DM.Add("09", "Saint Patrick");
            cc_reg_DM.Add("10", "Saint Paul");
            cc_reg_DM.Add("11", "Saint Peter");
            GEOIP_REGION_NAME.Add("DM", cc_reg_DM);
            Hashtable cc_reg_DO = new Hashtable();
            cc_reg_DO.Add("01", "Azua");
            cc_reg_DO.Add("02", "Baoruco");
            cc_reg_DO.Add("03", "Barahona");
            cc_reg_DO.Add("04", "Dajabon");
            cc_reg_DO.Add("05", "Distrito Nacional");
            cc_reg_DO.Add("06", "Duarte");
            cc_reg_DO.Add("08", "Espaillat");
            cc_reg_DO.Add("09", "Independencia");
            cc_reg_DO.Add("10", "La Altagracia");
            cc_reg_DO.Add("11", "Elias Pina");
            cc_reg_DO.Add("12", "La Romana");
            cc_reg_DO.Add("14", "Maria Trinidad Sanchez");
            cc_reg_DO.Add("15", "Monte Cristi");
            cc_reg_DO.Add("16", "Pedernales");
            cc_reg_DO.Add("17", "Peravia");
            cc_reg_DO.Add("18", "Puerto Plata");
            cc_reg_DO.Add("19", "Salcedo");
            cc_reg_DO.Add("20", "Samana");
            cc_reg_DO.Add("21", "Sanchez Ramirez");
            cc_reg_DO.Add("23", "San Juan");
            cc_reg_DO.Add("24", "San Pedro De Macoris");
            cc_reg_DO.Add("25", "Santiago");
            cc_reg_DO.Add("26", "Santiago Rodriguez");
            cc_reg_DO.Add("27", "Valverde");
            cc_reg_DO.Add("28", "El Seibo");
            cc_reg_DO.Add("29", "Hato Mayor");
            cc_reg_DO.Add("30", "La Vega");
            cc_reg_DO.Add("31", "Monsenor Nouel");
            cc_reg_DO.Add("32", "Monte Plata");
            cc_reg_DO.Add("33", "San Cristobal");
            cc_reg_DO.Add("34", "Distrito Nacional");
            cc_reg_DO.Add("35", "Peravia");
            cc_reg_DO.Add("36", "San Jose de Ocoa");
            cc_reg_DO.Add("37", "Santo Domingo");
            GEOIP_REGION_NAME.Add("DO", cc_reg_DO);
            Hashtable cc_reg_DZ = new Hashtable();
            cc_reg_DZ.Add("01", "Alger");
            cc_reg_DZ.Add("03", "Batna");
            cc_reg_DZ.Add("04", "Constantine");
            cc_reg_DZ.Add("06", "Medea");
            cc_reg_DZ.Add("07", "Mostaganem");
            cc_reg_DZ.Add("09", "Oran");
            cc_reg_DZ.Add("10", "Saida");
            cc_reg_DZ.Add("12", "Setif");
            cc_reg_DZ.Add("13", "Tiaret");
            cc_reg_DZ.Add("14", "Tizi Ouzou");
            cc_reg_DZ.Add("15", "Tlemcen");
            cc_reg_DZ.Add("18", "Bejaia");
            cc_reg_DZ.Add("19", "Biskra");
            cc_reg_DZ.Add("20", "Blida");
            cc_reg_DZ.Add("21", "Bouira");
            cc_reg_DZ.Add("22", "Djelfa");
            cc_reg_DZ.Add("23", "Guelma");
            cc_reg_DZ.Add("24", "Jijel");
            cc_reg_DZ.Add("25", "Laghouat");
            cc_reg_DZ.Add("26", "Mascara");
            cc_reg_DZ.Add("27", "M'sila");
            cc_reg_DZ.Add("29", "Oum el Bouaghi");
            cc_reg_DZ.Add("30", "Sidi Bel Abbes");
            cc_reg_DZ.Add("31", "Skikda");
            cc_reg_DZ.Add("33", "Tebessa");
            cc_reg_DZ.Add("34", "Adrar");
            cc_reg_DZ.Add("35", "Ain Defla");
            cc_reg_DZ.Add("36", "Ain Temouchent");
            cc_reg_DZ.Add("37", "Annaba");
            cc_reg_DZ.Add("38", "Bechar");
            cc_reg_DZ.Add("39", "Bordj Bou Arreridj");
            cc_reg_DZ.Add("40", "Boumerdes");
            cc_reg_DZ.Add("41", "Chlef");
            cc_reg_DZ.Add("42", "El Bayadh");
            cc_reg_DZ.Add("43", "El Oued");
            cc_reg_DZ.Add("44", "El Tarf");
            cc_reg_DZ.Add("45", "Ghardaia");
            cc_reg_DZ.Add("46", "Illizi");
            cc_reg_DZ.Add("47", "Khenchela");
            cc_reg_DZ.Add("48", "Mila");
            cc_reg_DZ.Add("49", "Naama");
            cc_reg_DZ.Add("50", "Ouargla");
            cc_reg_DZ.Add("51", "Relizane");
            cc_reg_DZ.Add("52", "Souk Ahras");
            cc_reg_DZ.Add("53", "Tamanghasset");
            cc_reg_DZ.Add("54", "Tindouf");
            cc_reg_DZ.Add("55", "Tipaza");
            cc_reg_DZ.Add("56", "Tissemsilt");
            GEOIP_REGION_NAME.Add("DZ", cc_reg_DZ);
            Hashtable cc_reg_EC = new Hashtable();
            cc_reg_EC.Add("01", "Galapagos");
            cc_reg_EC.Add("02", "Azuay");
            cc_reg_EC.Add("03", "Bolivar");
            cc_reg_EC.Add("04", "Canar");
            cc_reg_EC.Add("05", "Carchi");
            cc_reg_EC.Add("06", "Chimborazo");
            cc_reg_EC.Add("07", "Cotopaxi");
            cc_reg_EC.Add("08", "El Oro");
            cc_reg_EC.Add("09", "Esmeraldas");
            cc_reg_EC.Add("10", "Guayas");
            cc_reg_EC.Add("11", "Imbabura");
            cc_reg_EC.Add("12", "Loja");
            cc_reg_EC.Add("13", "Los Rios");
            cc_reg_EC.Add("14", "Manabi");
            cc_reg_EC.Add("15", "Morona-Santiago");
            cc_reg_EC.Add("17", "Pastaza");
            cc_reg_EC.Add("18", "Pichincha");
            cc_reg_EC.Add("19", "Tungurahua");
            cc_reg_EC.Add("20", "Zamora-Chinchipe");
            cc_reg_EC.Add("22", "Sucumbios");
            cc_reg_EC.Add("23", "Napo");
            cc_reg_EC.Add("24", "Orellana");
            GEOIP_REGION_NAME.Add("EC", cc_reg_EC);
            Hashtable cc_reg_EE = new Hashtable();
            cc_reg_EE.Add("01", "Harjumaa");
            cc_reg_EE.Add("02", "Hiiumaa");
            cc_reg_EE.Add("03", "Ida-Virumaa");
            cc_reg_EE.Add("04", "Jarvamaa");
            cc_reg_EE.Add("05", "Jogevamaa");
            cc_reg_EE.Add("06", "Kohtla-Jarve");
            cc_reg_EE.Add("07", "Laanemaa");
            cc_reg_EE.Add("08", "Laane-Virumaa");
            cc_reg_EE.Add("09", "Narva");
            cc_reg_EE.Add("10", "Parnu");
            cc_reg_EE.Add("11", "Parnumaa");
            cc_reg_EE.Add("12", "Polvamaa");
            cc_reg_EE.Add("13", "Raplamaa");
            cc_reg_EE.Add("14", "Saaremaa");
            cc_reg_EE.Add("15", "Sillamae");
            cc_reg_EE.Add("16", "Tallinn");
            cc_reg_EE.Add("17", "Tartu");
            cc_reg_EE.Add("18", "Tartumaa");
            cc_reg_EE.Add("19", "Valgamaa");
            cc_reg_EE.Add("20", "Viljandimaa");
            cc_reg_EE.Add("21", "Vorumaa");
            GEOIP_REGION_NAME.Add("EE", cc_reg_EE);
            Hashtable cc_reg_EG = new Hashtable();
            cc_reg_EG.Add("01", "Ad Daqahliyah");
            cc_reg_EG.Add("02", "Al Bahr al Ahmar");
            cc_reg_EG.Add("03", "Al Buhayrah");
            cc_reg_EG.Add("04", "Al Fayyum");
            cc_reg_EG.Add("05", "Al Gharbiyah");
            cc_reg_EG.Add("06", "Al Iskandariyah");
            cc_reg_EG.Add("07", "Al Isma'iliyah");
            cc_reg_EG.Add("08", "Al Jizah");
            cc_reg_EG.Add("09", "Al Minufiyah");
            cc_reg_EG.Add("10", "Al Minya");
            cc_reg_EG.Add("11", "Al Qahirah");
            cc_reg_EG.Add("12", "Al Qalyubiyah");
            cc_reg_EG.Add("13", "Al Wadi al Jadid");
            cc_reg_EG.Add("14", "Ash Sharqiyah");
            cc_reg_EG.Add("15", "As Suways");
            cc_reg_EG.Add("16", "Aswan");
            cc_reg_EG.Add("17", "Asyut");
            cc_reg_EG.Add("18", "Bani Suwayf");
            cc_reg_EG.Add("19", "Bur Sa'id");
            cc_reg_EG.Add("20", "Dumyat");
            cc_reg_EG.Add("21", "Kafr ash Shaykh");
            cc_reg_EG.Add("22", "Matruh");
            cc_reg_EG.Add("23", "Qina");
            cc_reg_EG.Add("24", "Suhaj");
            cc_reg_EG.Add("26", "Janub Sina'");
            cc_reg_EG.Add("27", "Shamal Sina'");
            GEOIP_REGION_NAME.Add("EG", cc_reg_EG);
            Hashtable cc_reg_ER = new Hashtable();
            cc_reg_ER.Add("01", "Anseba");
            cc_reg_ER.Add("02", "Debub");
            cc_reg_ER.Add("03", "Debubawi K'eyih Bahri");
            cc_reg_ER.Add("04", "Gash Barka");
            cc_reg_ER.Add("05", "Ma'akel");
            cc_reg_ER.Add("06", "Semenawi K'eyih Bahri");
            GEOIP_REGION_NAME.Add("ER", cc_reg_ER);
            Hashtable cc_reg_ES = new Hashtable();
            cc_reg_ES.Add("07", "Islas Baleares");
            cc_reg_ES.Add("27", "La Rioja");
            cc_reg_ES.Add("29", "Madrid");
            cc_reg_ES.Add("31", "Murcia");
            cc_reg_ES.Add("32", "Navarra");
            cc_reg_ES.Add("34", "Asturias");
            cc_reg_ES.Add("39", "Cantabria");
            cc_reg_ES.Add("51", "Andalucia");
            cc_reg_ES.Add("52", "Aragon");
            cc_reg_ES.Add("53", "Canarias");
            cc_reg_ES.Add("54", "Castilla-La Mancha");
            cc_reg_ES.Add("55", "Castilla y Leon");
            cc_reg_ES.Add("56", "Catalonia");
            cc_reg_ES.Add("57", "Extremadura");
            cc_reg_ES.Add("58", "Galicia");
            cc_reg_ES.Add("59", "Pais Vasco");
            cc_reg_ES.Add("60", "Comunidad Valenciana");
            GEOIP_REGION_NAME.Add("ES", cc_reg_ES);
            Hashtable cc_reg_ET = new Hashtable();
            cc_reg_ET.Add("44", "Adis Abeba");
            cc_reg_ET.Add("45", "Afar");
            cc_reg_ET.Add("46", "Amara");
            cc_reg_ET.Add("47", "Binshangul Gumuz");
            cc_reg_ET.Add("48", "Dire Dawa");
            cc_reg_ET.Add("49", "Gambela Hizboch");
            cc_reg_ET.Add("50", "Hareri Hizb");
            cc_reg_ET.Add("51", "Oromiya");
            cc_reg_ET.Add("52", "Sumale");
            cc_reg_ET.Add("53", "Tigray");
            cc_reg_ET.Add("54", "YeDebub Biheroch Bihereseboch na Hizboch");
            GEOIP_REGION_NAME.Add("ET", cc_reg_ET);
            Hashtable cc_reg_FI = new Hashtable();
            cc_reg_FI.Add("01", "Aland");
            cc_reg_FI.Add("06", "Lapland");
            cc_reg_FI.Add("08", "Oulu");
            cc_reg_FI.Add("13", "Southern Finland");
            cc_reg_FI.Add("14", "Eastern Finland");
            cc_reg_FI.Add("15", "Western Finland");
            GEOIP_REGION_NAME.Add("FI", cc_reg_FI);
            Hashtable cc_reg_FJ = new Hashtable();
            cc_reg_FJ.Add("01", "Central");
            cc_reg_FJ.Add("02", "Eastern");
            cc_reg_FJ.Add("03", "Northern");
            cc_reg_FJ.Add("04", "Rotuma");
            cc_reg_FJ.Add("05", "Western");
            GEOIP_REGION_NAME.Add("FJ", cc_reg_FJ);
            Hashtable cc_reg_FM = new Hashtable();
            cc_reg_FM.Add("01", "Kosrae");
            cc_reg_FM.Add("02", "Pohnpei");
            cc_reg_FM.Add("03", "Chuuk");
            cc_reg_FM.Add("04", "Yap");
            GEOIP_REGION_NAME.Add("FM", cc_reg_FM);
            Hashtable cc_reg_FR = new Hashtable();
            cc_reg_FR.Add("97", "Aquitaine");
            cc_reg_FR.Add("98", "Auvergne");
            cc_reg_FR.Add("99", "Basse-Normandie");
            cc_reg_FR.Add("A1", "Bourgogne");
            cc_reg_FR.Add("A2", "Bretagne");
            cc_reg_FR.Add("A3", "Centre");
            cc_reg_FR.Add("A4", "Champagne-Ardenne");
            cc_reg_FR.Add("A5", "Corse");
            cc_reg_FR.Add("A6", "Franche-Comte");
            cc_reg_FR.Add("A7", "Haute-Normandie");
            cc_reg_FR.Add("A8", "Ile-de-France");
            cc_reg_FR.Add("A9", "Languedoc-Roussillon");
            cc_reg_FR.Add("B1", "Limousin");
            cc_reg_FR.Add("B2", "Lorraine");
            cc_reg_FR.Add("B3", "Midi-Pyrenees");
            cc_reg_FR.Add("B4", "Nord-Pas-de-Calais");
            cc_reg_FR.Add("B5", "Pays de la Loire");
            cc_reg_FR.Add("B6", "Picardie");
            cc_reg_FR.Add("B7", "Poitou-Charentes");
            cc_reg_FR.Add("B8", "Provence-Alpes-Cote d'Azur");
            cc_reg_FR.Add("B9", "Rhone-Alpes");
            cc_reg_FR.Add("C1", "Alsace");
            GEOIP_REGION_NAME.Add("FR", cc_reg_FR);
            Hashtable cc_reg_GA = new Hashtable();
            cc_reg_GA.Add("01", "Estuaire");
            cc_reg_GA.Add("02", "Haut-Ogooue");
            cc_reg_GA.Add("03", "Moyen-Ogooue");
            cc_reg_GA.Add("04", "Ngounie");
            cc_reg_GA.Add("05", "Nyanga");
            cc_reg_GA.Add("06", "Ogooue-Ivindo");
            cc_reg_GA.Add("07", "Ogooue-Lolo");
            cc_reg_GA.Add("08", "Ogooue-Maritime");
            cc_reg_GA.Add("09", "Woleu-Ntem");
            GEOIP_REGION_NAME.Add("GA", cc_reg_GA);
            Hashtable cc_reg_GB = new Hashtable();
            cc_reg_GB.Add("A1", "Barking and Dagenham");
            cc_reg_GB.Add("A2", "Barnet");
            cc_reg_GB.Add("A3", "Barnsley");
            cc_reg_GB.Add("A4", "Bath and North East Somerset");
            cc_reg_GB.Add("A5", "Bedfordshire");
            cc_reg_GB.Add("A6", "Bexley");
            cc_reg_GB.Add("A7", "Birmingham");
            cc_reg_GB.Add("A8", "Blackburn with Darwen");
            cc_reg_GB.Add("A9", "Blackpool");
            cc_reg_GB.Add("B1", "Bolton");
            cc_reg_GB.Add("B2", "Bournemouth");
            cc_reg_GB.Add("B3", "Bracknell Forest");
            cc_reg_GB.Add("B4", "Bradford");
            cc_reg_GB.Add("B5", "Brent");
            cc_reg_GB.Add("B6", "Brighton and Hove");
            cc_reg_GB.Add("B7", "Bristol, City of");
            cc_reg_GB.Add("B8", "Bromley");
            cc_reg_GB.Add("B9", "Buckinghamshire");
            cc_reg_GB.Add("C1", "Bury");
            cc_reg_GB.Add("C2", "Calderdale");
            cc_reg_GB.Add("C3", "Cambridgeshire");
            cc_reg_GB.Add("C4", "Camden");
            cc_reg_GB.Add("C5", "Cheshire");
            cc_reg_GB.Add("C6", "Cornwall");
            cc_reg_GB.Add("C7", "Coventry");
            cc_reg_GB.Add("C8", "Croydon");
            cc_reg_GB.Add("C9", "Cumbria");
            cc_reg_GB.Add("D1", "Darlington");
            cc_reg_GB.Add("D2", "Derby");
            cc_reg_GB.Add("D3", "Derbyshire");
            cc_reg_GB.Add("D4", "Devon");
            cc_reg_GB.Add("D5", "Doncaster");
            cc_reg_GB.Add("D6", "Dorset");
            cc_reg_GB.Add("D7", "Dudley");
            cc_reg_GB.Add("D8", "Durham");
            cc_reg_GB.Add("D9", "Ealing");
            cc_reg_GB.Add("E1", "East Riding of Yorkshire");
            cc_reg_GB.Add("E2", "East Sussex");
            cc_reg_GB.Add("E3", "Enfield");
            cc_reg_GB.Add("E4", "Essex");
            cc_reg_GB.Add("E5", "Gateshead");
            cc_reg_GB.Add("E6", "Gloucestershire");
            cc_reg_GB.Add("E7", "Greenwich");
            cc_reg_GB.Add("E8", "Hackney");
            cc_reg_GB.Add("E9", "Halton");
            cc_reg_GB.Add("F1", "Hammersmith and Fulham");
            cc_reg_GB.Add("F2", "Hampshire");
            cc_reg_GB.Add("F3", "Haringey");
            cc_reg_GB.Add("F4", "Harrow");
            cc_reg_GB.Add("F5", "Hartlepool");
            cc_reg_GB.Add("F6", "Havering");
            cc_reg_GB.Add("F7", "Herefordshire");
            cc_reg_GB.Add("F8", "Hertford");
            cc_reg_GB.Add("F9", "Hillingdon");
            cc_reg_GB.Add("G1", "Hounslow");
            cc_reg_GB.Add("G2", "Isle of Wight");
            cc_reg_GB.Add("G3", "Islington");
            cc_reg_GB.Add("G4", "Kensington and Chelsea");
            cc_reg_GB.Add("G5", "Kent");
            cc_reg_GB.Add("G6", "Kingston upon Hull, City of");
            cc_reg_GB.Add("G7", "Kingston upon Thames");
            cc_reg_GB.Add("G8", "Kirklees");
            cc_reg_GB.Add("G9", "Knowsley");
            cc_reg_GB.Add("H1", "Lambeth");
            cc_reg_GB.Add("H2", "Lancashire");
            cc_reg_GB.Add("H3", "Leeds");
            cc_reg_GB.Add("H4", "Leicester");
            cc_reg_GB.Add("H5", "Leicestershire");
            cc_reg_GB.Add("H6", "Lewisham");
            cc_reg_GB.Add("H7", "Lincolnshire");
            cc_reg_GB.Add("H8", "Liverpool");
            cc_reg_GB.Add("H9", "London, City of");
            cc_reg_GB.Add("I1", "Luton");
            cc_reg_GB.Add("I2", "Manchester");
            cc_reg_GB.Add("I3", "Medway");
            cc_reg_GB.Add("I4", "Merton");
            cc_reg_GB.Add("I5", "Middlesbrough");
            cc_reg_GB.Add("I6", "Milton Keynes");
            cc_reg_GB.Add("I7", "Newcastle upon Tyne");
            cc_reg_GB.Add("I8", "Newham");
            cc_reg_GB.Add("I9", "Norfolk");
            cc_reg_GB.Add("J1", "Northamptonshire");
            cc_reg_GB.Add("J2", "North East Lincolnshire");
            cc_reg_GB.Add("J3", "North Lincolnshire");
            cc_reg_GB.Add("J4", "North Somerset");
            cc_reg_GB.Add("J5", "North Tyneside");
            cc_reg_GB.Add("J6", "Northumberland");
            cc_reg_GB.Add("J7", "North Yorkshire");
            cc_reg_GB.Add("J8", "Nottingham");
            cc_reg_GB.Add("J9", "Nottinghamshire");
            cc_reg_GB.Add("K1", "Oldham");
            cc_reg_GB.Add("K2", "Oxfordshire");
            cc_reg_GB.Add("K3", "Peterborough");
            cc_reg_GB.Add("K4", "Plymouth");
            cc_reg_GB.Add("K5", "Poole");
            cc_reg_GB.Add("K6", "Portsmouth");
            cc_reg_GB.Add("K7", "Reading");
            cc_reg_GB.Add("K8", "Redbridge");
            cc_reg_GB.Add("K9", "Redcar and Cleveland");
            cc_reg_GB.Add("L1", "Richmond upon Thames");
            cc_reg_GB.Add("L2", "Rochdale");
            cc_reg_GB.Add("L3", "Rotherham");
            cc_reg_GB.Add("L4", "Rutland");
            cc_reg_GB.Add("L5", "Salford");
            cc_reg_GB.Add("L6", "Shropshire");
            cc_reg_GB.Add("L7", "Sandwell");
            cc_reg_GB.Add("L8", "Sefton");
            cc_reg_GB.Add("L9", "Sheffield");
            cc_reg_GB.Add("M1", "Slough");
            cc_reg_GB.Add("M2", "Solihull");
            cc_reg_GB.Add("M3", "Somerset");
            cc_reg_GB.Add("M4", "Southampton");
            cc_reg_GB.Add("M5", "Southend-on-Sea");
            cc_reg_GB.Add("M6", "South Gloucestershire");
            cc_reg_GB.Add("M7", "South Tyneside");
            cc_reg_GB.Add("M8", "Southwark");
            cc_reg_GB.Add("M9", "Staffordshire");
            cc_reg_GB.Add("N1", "St. Helens");
            cc_reg_GB.Add("N2", "Stockport");
            cc_reg_GB.Add("N3", "Stockton-on-Tees");
            cc_reg_GB.Add("N4", "Stoke-on-Trent");
            cc_reg_GB.Add("N5", "Suffolk");
            cc_reg_GB.Add("N6", "Sunderland");
            cc_reg_GB.Add("N7", "Surrey");
            cc_reg_GB.Add("N8", "Sutton");
            cc_reg_GB.Add("N9", "Swindon");
            cc_reg_GB.Add("O1", "Tameside");
            cc_reg_GB.Add("O2", "Telford and Wrekin");
            cc_reg_GB.Add("O3", "Thurrock");
            cc_reg_GB.Add("O4", "Torbay");
            cc_reg_GB.Add("O5", "Tower Hamlets");
            cc_reg_GB.Add("O6", "Trafford");
            cc_reg_GB.Add("O7", "Wakefield");
            cc_reg_GB.Add("O8", "Walsall");
            cc_reg_GB.Add("O9", "Waltham Forest");
            cc_reg_GB.Add("P1", "Wandsworth");
            cc_reg_GB.Add("P2", "Warrington");
            cc_reg_GB.Add("P3", "Warwickshire");
            cc_reg_GB.Add("P4", "West Berkshire");
            cc_reg_GB.Add("P5", "Westminster");
            cc_reg_GB.Add("P6", "West Sussex");
            cc_reg_GB.Add("P7", "Wigan");
            cc_reg_GB.Add("P8", "Wiltshire");
            cc_reg_GB.Add("P9", "Windsor and Maidenhead");
            cc_reg_GB.Add("Q1", "Wirral");
            cc_reg_GB.Add("Q2", "Wokingham");
            cc_reg_GB.Add("Q3", "Wolverhampton");
            cc_reg_GB.Add("Q4", "Worcestershire");
            cc_reg_GB.Add("Q5", "York");
            cc_reg_GB.Add("Q6", "Antrim");
            cc_reg_GB.Add("Q7", "Ards");
            cc_reg_GB.Add("Q8", "Armagh");
            cc_reg_GB.Add("Q9", "Ballymena");
            cc_reg_GB.Add("R1", "Ballymoney");
            cc_reg_GB.Add("R2", "Banbridge");
            cc_reg_GB.Add("R3", "Belfast");
            cc_reg_GB.Add("R4", "Carrickfergus");
            cc_reg_GB.Add("R5", "Castlereagh");
            cc_reg_GB.Add("R6", "Coleraine");
            cc_reg_GB.Add("R7", "Cookstown");
            cc_reg_GB.Add("R8", "Craigavon");
            cc_reg_GB.Add("R9", "Down");
            cc_reg_GB.Add("S1", "Dungannon");
            cc_reg_GB.Add("S2", "Fermanagh");
            cc_reg_GB.Add("S3", "Larne");
            cc_reg_GB.Add("S4", "Limavady");
            cc_reg_GB.Add("S5", "Lisburn");
            cc_reg_GB.Add("S6", "Derry");
            cc_reg_GB.Add("S7", "Magherafelt");
            cc_reg_GB.Add("S8", "Moyle");
            cc_reg_GB.Add("S9", "Newry and Mourne");
            cc_reg_GB.Add("T1", "Newtownabbey");
            cc_reg_GB.Add("T2", "North Down");
            cc_reg_GB.Add("T3", "Omagh");
            cc_reg_GB.Add("T4", "Strabane");
            cc_reg_GB.Add("T5", "Aberdeen City");
            cc_reg_GB.Add("T6", "Aberdeenshire");
            cc_reg_GB.Add("T7", "Angus");
            cc_reg_GB.Add("T8", "Argyll and Bute");
            cc_reg_GB.Add("T9", "Scottish Borders, The");
            cc_reg_GB.Add("U1", "Clackmannanshire");
            cc_reg_GB.Add("U2", "Dumfries and Galloway");
            cc_reg_GB.Add("U3", "Dundee City");
            cc_reg_GB.Add("U4", "East Ayrshire");
            cc_reg_GB.Add("U5", "East Dunbartonshire");
            cc_reg_GB.Add("U6", "East Lothian");
            cc_reg_GB.Add("U7", "East Renfrewshire");
            cc_reg_GB.Add("U8", "Edinburgh, City of");
            cc_reg_GB.Add("U9", "Falkirk");
            cc_reg_GB.Add("V1", "Fife");
            cc_reg_GB.Add("V2", "Glasgow City");
            cc_reg_GB.Add("V3", "Highland");
            cc_reg_GB.Add("V4", "Inverclyde");
            cc_reg_GB.Add("V5", "Midlothian");
            cc_reg_GB.Add("V6", "Moray");
            cc_reg_GB.Add("V7", "North Ayrshire");
            cc_reg_GB.Add("V8", "North Lanarkshire");
            cc_reg_GB.Add("V9", "Orkney");
            cc_reg_GB.Add("W1", "Perth and Kinross");
            cc_reg_GB.Add("W2", "Renfrewshire");
            cc_reg_GB.Add("W3", "Shetland Islands");
            cc_reg_GB.Add("W4", "South Ayrshire");
            cc_reg_GB.Add("W5", "South Lanarkshire");
            cc_reg_GB.Add("W6", "Stirling");
            cc_reg_GB.Add("W7", "West Dunbartonshire");
            cc_reg_GB.Add("W8", "Eilean Siar");
            cc_reg_GB.Add("W9", "West Lothian");
            cc_reg_GB.Add("X1", "Isle of Anglesey");
            cc_reg_GB.Add("X2", "Blaenau Gwent");
            cc_reg_GB.Add("X3", "Bridgend");
            cc_reg_GB.Add("X4", "Caerphilly");
            cc_reg_GB.Add("X5", "Cardiff");
            cc_reg_GB.Add("X6", "Ceredigion");
            cc_reg_GB.Add("X7", "Carmarthenshire");
            cc_reg_GB.Add("X8", "Conwy");
            cc_reg_GB.Add("X9", "Denbighshire");
            cc_reg_GB.Add("Y1", "Flintshire");
            cc_reg_GB.Add("Y2", "Gwynedd");
            cc_reg_GB.Add("Y3", "Merthyr Tydfil");
            cc_reg_GB.Add("Y4", "Monmouthshire");
            cc_reg_GB.Add("Y5", "Neath Port Talbot");
            cc_reg_GB.Add("Y6", "Newport");
            cc_reg_GB.Add("Y7", "Pembrokeshire");
            cc_reg_GB.Add("Y8", "Powys");
            cc_reg_GB.Add("Y9", "Rhondda Cynon Taff");
            cc_reg_GB.Add("Z1", "Swansea");
            cc_reg_GB.Add("Z2", "Torfaen");
            cc_reg_GB.Add("Z3", "Vale of Glamorgan, The");
            cc_reg_GB.Add("Z4", "Wrexham");
            cc_reg_GB.Add("Z5", "Bedfordshire");
            cc_reg_GB.Add("Z6", "Central Bedfordshire");
            cc_reg_GB.Add("Z7", "Cheshire East");
            cc_reg_GB.Add("Z8", "Cheshire West and Chester");
            cc_reg_GB.Add("Z9", "Isles of Scilly");
            GEOIP_REGION_NAME.Add("GB", cc_reg_GB);
            Hashtable cc_reg_GD = new Hashtable();
            cc_reg_GD.Add("01", "Saint Andrew");
            cc_reg_GD.Add("02", "Saint David");
            cc_reg_GD.Add("03", "Saint George");
            cc_reg_GD.Add("04", "Saint John");
            cc_reg_GD.Add("05", "Saint Mark");
            cc_reg_GD.Add("06", "Saint Patrick");
            GEOIP_REGION_NAME.Add("GD", cc_reg_GD);
            Hashtable cc_reg_GE = new Hashtable();
            cc_reg_GE.Add("01", "Abashis Raioni");
            cc_reg_GE.Add("02", "Abkhazia");
            cc_reg_GE.Add("03", "Adigenis Raioni");
            cc_reg_GE.Add("04", "Ajaria");
            cc_reg_GE.Add("05", "Akhalgoris Raioni");
            cc_reg_GE.Add("06", "Akhalk'alak'is Raioni");
            cc_reg_GE.Add("07", "Akhalts'ikhis Raioni");
            cc_reg_GE.Add("08", "Akhmetis Raioni");
            cc_reg_GE.Add("09", "Ambrolauris Raioni");
            cc_reg_GE.Add("10", "Aspindzis Raioni");
            cc_reg_GE.Add("11", "Baghdat'is Raioni");
            cc_reg_GE.Add("12", "Bolnisis Raioni");
            cc_reg_GE.Add("13", "Borjomis Raioni");
            cc_reg_GE.Add("14", "Chiat'ura");
            cc_reg_GE.Add("15", "Ch'khorotsqus Raioni");
            cc_reg_GE.Add("16", "Ch'okhatauris Raioni");
            cc_reg_GE.Add("17", "Dedop'listsqaros Raioni");
            cc_reg_GE.Add("18", "Dmanisis Raioni");
            cc_reg_GE.Add("19", "Dushet'is Raioni");
            cc_reg_GE.Add("20", "Gardabanis Raioni");
            cc_reg_GE.Add("21", "Gori");
            cc_reg_GE.Add("22", "Goris Raioni");
            cc_reg_GE.Add("23", "Gurjaanis Raioni");
            cc_reg_GE.Add("24", "Javis Raioni");
            cc_reg_GE.Add("25", "K'arelis Raioni");
            cc_reg_GE.Add("26", "Kaspis Raioni");
            cc_reg_GE.Add("27", "Kharagaulis Raioni");
            cc_reg_GE.Add("28", "Khashuris Raioni");
            cc_reg_GE.Add("29", "Khobis Raioni");
            cc_reg_GE.Add("30", "Khonis Raioni");
            cc_reg_GE.Add("31", "K'ut'aisi");
            cc_reg_GE.Add("32", "Lagodekhis Raioni");
            cc_reg_GE.Add("33", "Lanch'khut'is Raioni");
            cc_reg_GE.Add("34", "Lentekhis Raioni");
            cc_reg_GE.Add("35", "Marneulis Raioni");
            cc_reg_GE.Add("36", "Martvilis Raioni");
            cc_reg_GE.Add("37", "Mestiis Raioni");
            cc_reg_GE.Add("38", "Mts'khet'is Raioni");
            cc_reg_GE.Add("39", "Ninotsmindis Raioni");
            cc_reg_GE.Add("40", "Onis Raioni");
            cc_reg_GE.Add("41", "Ozurget'is Raioni");
            cc_reg_GE.Add("42", "P'ot'i");
            cc_reg_GE.Add("43", "Qazbegis Raioni");
            cc_reg_GE.Add("44", "Qvarlis Raioni");
            cc_reg_GE.Add("45", "Rust'avi");
            cc_reg_GE.Add("46", "Sach'kheris Raioni");
            cc_reg_GE.Add("47", "Sagarejos Raioni");
            cc_reg_GE.Add("48", "Samtrediis Raioni");
            cc_reg_GE.Add("49", "Senakis Raioni");
            cc_reg_GE.Add("50", "Sighnaghis Raioni");
            cc_reg_GE.Add("51", "T'bilisi");
            cc_reg_GE.Add("52", "T'elavis Raioni");
            cc_reg_GE.Add("53", "T'erjolis Raioni");
            cc_reg_GE.Add("54", "T'et'ritsqaros Raioni");
            cc_reg_GE.Add("55", "T'ianet'is Raioni");
            cc_reg_GE.Add("56", "Tqibuli");
            cc_reg_GE.Add("57", "Ts'ageris Raioni");
            cc_reg_GE.Add("58", "Tsalenjikhis Raioni");
            cc_reg_GE.Add("59", "Tsalkis Raioni");
            cc_reg_GE.Add("60", "Tsqaltubo");
            cc_reg_GE.Add("61", "Vanis Raioni");
            cc_reg_GE.Add("62", "Zestap'onis Raioni");
            cc_reg_GE.Add("63", "Zugdidi");
            cc_reg_GE.Add("64", "Zugdidis Raioni");
            GEOIP_REGION_NAME.Add("GE", cc_reg_GE);
            Hashtable cc_reg_GH = new Hashtable();
            cc_reg_GH.Add("01", "Greater Accra");
            cc_reg_GH.Add("02", "Ashanti");
            cc_reg_GH.Add("03", "Brong-Ahafo");
            cc_reg_GH.Add("04", "Central");
            cc_reg_GH.Add("05", "Eastern");
            cc_reg_GH.Add("06", "Northern");
            cc_reg_GH.Add("08", "Volta");
            cc_reg_GH.Add("09", "Western");
            cc_reg_GH.Add("10", "Upper East");
            cc_reg_GH.Add("11", "Upper West");
            GEOIP_REGION_NAME.Add("GH", cc_reg_GH);
            Hashtable cc_reg_GL = new Hashtable();
            cc_reg_GL.Add("01", "Nordgronland");
            cc_reg_GL.Add("02", "Ostgronland");
            cc_reg_GL.Add("03", "Vestgronland");
            GEOIP_REGION_NAME.Add("GL", cc_reg_GL);
            Hashtable cc_reg_GM = new Hashtable();
            cc_reg_GM.Add("01", "Banjul");
            cc_reg_GM.Add("02", "Lower River");
            cc_reg_GM.Add("03", "Central River");
            cc_reg_GM.Add("04", "Upper River");
            cc_reg_GM.Add("05", "Western");
            cc_reg_GM.Add("07", "North Bank");
            GEOIP_REGION_NAME.Add("GM", cc_reg_GM);
            Hashtable cc_reg_GN = new Hashtable();
            cc_reg_GN.Add("01", "Beyla");
            cc_reg_GN.Add("02", "Boffa");
            cc_reg_GN.Add("03", "Boke");
            cc_reg_GN.Add("04", "Conakry");
            cc_reg_GN.Add("05", "Dabola");
            cc_reg_GN.Add("06", "Dalaba");
            cc_reg_GN.Add("07", "Dinguiraye");
            cc_reg_GN.Add("09", "Faranah");
            cc_reg_GN.Add("10", "Forecariah");
            cc_reg_GN.Add("11", "Fria");
            cc_reg_GN.Add("12", "Gaoual");
            cc_reg_GN.Add("13", "Gueckedou");
            cc_reg_GN.Add("15", "Kerouane");
            cc_reg_GN.Add("16", "Kindia");
            cc_reg_GN.Add("17", "Kissidougou");
            cc_reg_GN.Add("18", "Koundara");
            cc_reg_GN.Add("19", "Kouroussa");
            cc_reg_GN.Add("21", "Macenta");
            cc_reg_GN.Add("22", "Mali");
            cc_reg_GN.Add("23", "Mamou");
            cc_reg_GN.Add("25", "Pita");
            cc_reg_GN.Add("27", "Telimele");
            cc_reg_GN.Add("28", "Tougue");
            cc_reg_GN.Add("29", "Yomou");
            cc_reg_GN.Add("30", "Coyah");
            cc_reg_GN.Add("31", "Dubreka");
            cc_reg_GN.Add("32", "Kankan");
            cc_reg_GN.Add("33", "Koubia");
            cc_reg_GN.Add("34", "Labe");
            cc_reg_GN.Add("35", "Lelouma");
            cc_reg_GN.Add("36", "Lola");
            cc_reg_GN.Add("37", "Mandiana");
            cc_reg_GN.Add("38", "Nzerekore");
            cc_reg_GN.Add("39", "Siguiri");
            GEOIP_REGION_NAME.Add("GN", cc_reg_GN);
            Hashtable cc_reg_GQ = new Hashtable();
            cc_reg_GQ.Add("03", "Annobon");
            cc_reg_GQ.Add("04", "Bioko Norte");
            cc_reg_GQ.Add("05", "Bioko Sur");
            cc_reg_GQ.Add("06", "Centro Sur");
            cc_reg_GQ.Add("07", "Kie-Ntem");
            cc_reg_GQ.Add("08", "Litoral");
            cc_reg_GQ.Add("09", "Wele-Nzas");
            GEOIP_REGION_NAME.Add("GQ", cc_reg_GQ);
            Hashtable cc_reg_GR = new Hashtable();
            cc_reg_GR.Add("01", "Evros");
            cc_reg_GR.Add("02", "Rodhopi");
            cc_reg_GR.Add("03", "Xanthi");
            cc_reg_GR.Add("04", "Drama");
            cc_reg_GR.Add("05", "Serrai");
            cc_reg_GR.Add("06", "Kilkis");
            cc_reg_GR.Add("07", "Pella");
            cc_reg_GR.Add("08", "Florina");
            cc_reg_GR.Add("09", "Kastoria");
            cc_reg_GR.Add("10", "Grevena");
            cc_reg_GR.Add("11", "Kozani");
            cc_reg_GR.Add("12", "Imathia");
            cc_reg_GR.Add("13", "Thessaloniki");
            cc_reg_GR.Add("14", "Kavala");
            cc_reg_GR.Add("15", "Khalkidhiki");
            cc_reg_GR.Add("16", "Pieria");
            cc_reg_GR.Add("17", "Ioannina");
            cc_reg_GR.Add("18", "Thesprotia");
            cc_reg_GR.Add("19", "Preveza");
            cc_reg_GR.Add("20", "Arta");
            cc_reg_GR.Add("21", "Larisa");
            cc_reg_GR.Add("22", "Trikala");
            cc_reg_GR.Add("23", "Kardhitsa");
            cc_reg_GR.Add("24", "Magnisia");
            cc_reg_GR.Add("25", "Kerkira");
            cc_reg_GR.Add("26", "Levkas");
            cc_reg_GR.Add("27", "Kefallinia");
            cc_reg_GR.Add("28", "Zakinthos");
            cc_reg_GR.Add("29", "Fthiotis");
            cc_reg_GR.Add("30", "Evritania");
            cc_reg_GR.Add("31", "Aitolia kai Akarnania");
            cc_reg_GR.Add("32", "Fokis");
            cc_reg_GR.Add("33", "Voiotia");
            cc_reg_GR.Add("34", "Evvoia");
            cc_reg_GR.Add("35", "Attiki");
            cc_reg_GR.Add("36", "Argolis");
            cc_reg_GR.Add("37", "Korinthia");
            cc_reg_GR.Add("38", "Akhaia");
            cc_reg_GR.Add("39", "Ilia");
            cc_reg_GR.Add("40", "Messinia");
            cc_reg_GR.Add("41", "Arkadhia");
            cc_reg_GR.Add("42", "Lakonia");
            cc_reg_GR.Add("43", "Khania");
            cc_reg_GR.Add("44", "Rethimni");
            cc_reg_GR.Add("45", "Iraklion");
            cc_reg_GR.Add("46", "Lasithi");
            cc_reg_GR.Add("47", "Dhodhekanisos");
            cc_reg_GR.Add("48", "Samos");
            cc_reg_GR.Add("49", "Kikladhes");
            cc_reg_GR.Add("50", "Khios");
            cc_reg_GR.Add("51", "Lesvos");
            GEOIP_REGION_NAME.Add("GR", cc_reg_GR);
            Hashtable cc_reg_GT = new Hashtable();
            cc_reg_GT.Add("01", "Alta Verapaz");
            cc_reg_GT.Add("02", "Baja Verapaz");
            cc_reg_GT.Add("03", "Chimaltenango");
            cc_reg_GT.Add("04", "Chiquimula");
            cc_reg_GT.Add("05", "El Progreso");
            cc_reg_GT.Add("06", "Escuintla");
            cc_reg_GT.Add("07", "Guatemala");
            cc_reg_GT.Add("08", "Huehuetenango");
            cc_reg_GT.Add("09", "Izabal");
            cc_reg_GT.Add("10", "Jalapa");
            cc_reg_GT.Add("11", "Jutiapa");
            cc_reg_GT.Add("12", "Peten");
            cc_reg_GT.Add("13", "Quetzaltenango");
            cc_reg_GT.Add("14", "Quiche");
            cc_reg_GT.Add("15", "Retalhuleu");
            cc_reg_GT.Add("16", "Sacatepequez");
            cc_reg_GT.Add("17", "San Marcos");
            cc_reg_GT.Add("18", "Santa Rosa");
            cc_reg_GT.Add("19", "Solola");
            cc_reg_GT.Add("20", "Suchitepequez");
            cc_reg_GT.Add("21", "Totonicapan");
            cc_reg_GT.Add("22", "Zacapa");
            GEOIP_REGION_NAME.Add("GT", cc_reg_GT);
            Hashtable cc_reg_GW = new Hashtable();
            cc_reg_GW.Add("01", "Bafata");
            cc_reg_GW.Add("02", "Quinara");
            cc_reg_GW.Add("04", "Oio");
            cc_reg_GW.Add("05", "Bolama");
            cc_reg_GW.Add("06", "Cacheu");
            cc_reg_GW.Add("07", "Tombali");
            cc_reg_GW.Add("10", "Gabu");
            cc_reg_GW.Add("11", "Bissau");
            cc_reg_GW.Add("12", "Biombo");
            GEOIP_REGION_NAME.Add("GW", cc_reg_GW);
            Hashtable cc_reg_GY = new Hashtable();
            cc_reg_GY.Add("10", "Barima-Waini");
            cc_reg_GY.Add("11", "Cuyuni-Mazaruni");
            cc_reg_GY.Add("12", "Demerara-Mahaica");
            cc_reg_GY.Add("13", "East Berbice-Corentyne");
            cc_reg_GY.Add("14", "Essequibo Islands-West Demerara");
            cc_reg_GY.Add("15", "Mahaica-Berbice");
            cc_reg_GY.Add("16", "Pomeroon-Supenaam");
            cc_reg_GY.Add("17", "Potaro-Siparuni");
            cc_reg_GY.Add("18", "Upper Demerara-Berbice");
            cc_reg_GY.Add("19", "Upper Takutu-Upper Essequibo");
            GEOIP_REGION_NAME.Add("GY", cc_reg_GY);
            Hashtable cc_reg_HN = new Hashtable();
            cc_reg_HN.Add("01", "Atlantida");
            cc_reg_HN.Add("02", "Choluteca");
            cc_reg_HN.Add("03", "Colon");
            cc_reg_HN.Add("04", "Comayagua");
            cc_reg_HN.Add("05", "Copan");
            cc_reg_HN.Add("06", "Cortes");
            cc_reg_HN.Add("07", "El Paraiso");
            cc_reg_HN.Add("08", "Francisco Morazan");
            cc_reg_HN.Add("09", "Gracias a Dios");
            cc_reg_HN.Add("10", "Intibuca");
            cc_reg_HN.Add("11", "Islas de la Bahia");
            cc_reg_HN.Add("12", "La Paz");
            cc_reg_HN.Add("13", "Lempira");
            cc_reg_HN.Add("14", "Ocotepeque");
            cc_reg_HN.Add("15", "Olancho");
            cc_reg_HN.Add("16", "Santa Barbara");
            cc_reg_HN.Add("17", "Valle");
            cc_reg_HN.Add("18", "Yoro");
            GEOIP_REGION_NAME.Add("HN", cc_reg_HN);
            Hashtable cc_reg_HR = new Hashtable();
            cc_reg_HR.Add("01", "Bjelovarsko-Bilogorska");
            cc_reg_HR.Add("02", "Brodsko-Posavska");
            cc_reg_HR.Add("03", "Dubrovacko-Neretvanska");
            cc_reg_HR.Add("04", "Istarska");
            cc_reg_HR.Add("05", "Karlovacka");
            cc_reg_HR.Add("06", "Koprivnicko-Krizevacka");
            cc_reg_HR.Add("07", "Krapinsko-Zagorska");
            cc_reg_HR.Add("08", "Licko-Senjska");
            cc_reg_HR.Add("09", "Medimurska");
            cc_reg_HR.Add("10", "Osjecko-Baranjska");
            cc_reg_HR.Add("11", "Pozesko-Slavonska");
            cc_reg_HR.Add("12", "Primorsko-Goranska");
            cc_reg_HR.Add("13", "Sibensko-Kninska");
            cc_reg_HR.Add("14", "Sisacko-Moslavacka");
            cc_reg_HR.Add("15", "Splitsko-Dalmatinska");
            cc_reg_HR.Add("16", "Varazdinska");
            cc_reg_HR.Add("17", "Viroviticko-Podravska");
            cc_reg_HR.Add("18", "Vukovarsko-Srijemska");
            cc_reg_HR.Add("19", "Zadarska");
            cc_reg_HR.Add("20", "Zagrebacka");
            cc_reg_HR.Add("21", "Grad Zagreb");
            GEOIP_REGION_NAME.Add("HR", cc_reg_HR);
            Hashtable cc_reg_HT = new Hashtable();
            cc_reg_HT.Add("03", "Nord-Ouest");
            cc_reg_HT.Add("06", "Artibonite");
            cc_reg_HT.Add("07", "Centre");
            cc_reg_HT.Add("09", "Nord");
            cc_reg_HT.Add("10", "Nord-Est");
            cc_reg_HT.Add("11", "Ouest");
            cc_reg_HT.Add("12", "Sud");
            cc_reg_HT.Add("13", "Sud-Est");
            cc_reg_HT.Add("14", "Grand' Anse");
            cc_reg_HT.Add("15", "Nippes");
            GEOIP_REGION_NAME.Add("HT", cc_reg_HT);
            Hashtable cc_reg_HU = new Hashtable();
            cc_reg_HU.Add("01", "Bacs-Kiskun");
            cc_reg_HU.Add("02", "Baranya");
            cc_reg_HU.Add("03", "Bekes");
            cc_reg_HU.Add("04", "Borsod-Abauj-Zemplen");
            cc_reg_HU.Add("05", "Budapest");
            cc_reg_HU.Add("06", "Csongrad");
            cc_reg_HU.Add("07", "Debrecen");
            cc_reg_HU.Add("08", "Fejer");
            cc_reg_HU.Add("09", "Gyor-Moson-Sopron");
            cc_reg_HU.Add("10", "Hajdu-Bihar");
            cc_reg_HU.Add("11", "Heves");
            cc_reg_HU.Add("12", "Komarom-Esztergom");
            cc_reg_HU.Add("13", "Miskolc");
            cc_reg_HU.Add("14", "Nograd");
            cc_reg_HU.Add("15", "Pecs");
            cc_reg_HU.Add("16", "Pest");
            cc_reg_HU.Add("17", "Somogy");
            cc_reg_HU.Add("18", "Szabolcs-Szatmar-Bereg");
            cc_reg_HU.Add("19", "Szeged");
            cc_reg_HU.Add("20", "Jasz-Nagykun-Szolnok");
            cc_reg_HU.Add("21", "Tolna");
            cc_reg_HU.Add("22", "Vas");
            cc_reg_HU.Add("23", "Veszprem");
            cc_reg_HU.Add("24", "Zala");
            cc_reg_HU.Add("25", "Gyor");
            cc_reg_HU.Add("26", "Bekescsaba");
            cc_reg_HU.Add("27", "Dunaujvaros");
            cc_reg_HU.Add("28", "Eger");
            cc_reg_HU.Add("29", "Hodmezovasarhely");
            cc_reg_HU.Add("30", "Kaposvar");
            cc_reg_HU.Add("31", "Kecskemet");
            cc_reg_HU.Add("32", "Nagykanizsa");
            cc_reg_HU.Add("33", "Nyiregyhaza");
            cc_reg_HU.Add("34", "Sopron");
            cc_reg_HU.Add("35", "Szekesfehervar");
            cc_reg_HU.Add("36", "Szolnok");
            cc_reg_HU.Add("37", "Szombathely");
            cc_reg_HU.Add("38", "Tatabanya");
            cc_reg_HU.Add("39", "Veszprem");
            cc_reg_HU.Add("40", "Zalaegerszeg");
            cc_reg_HU.Add("41", "Salgotarjan");
            cc_reg_HU.Add("42", "Szekszard");
            cc_reg_HU.Add("43", "Erd");
            GEOIP_REGION_NAME.Add("HU", cc_reg_HU);
            Hashtable cc_reg_ID = new Hashtable();
            cc_reg_ID.Add("01", "Aceh");
            cc_reg_ID.Add("02", "Bali");
            cc_reg_ID.Add("03", "Bengkulu");
            cc_reg_ID.Add("04", "Jakarta Raya");
            cc_reg_ID.Add("05", "Jambi");
            cc_reg_ID.Add("07", "Jawa Tengah");
            cc_reg_ID.Add("08", "Jawa Timur");
            cc_reg_ID.Add("10", "Yogyakarta");
            cc_reg_ID.Add("11", "Kalimantan Barat");
            cc_reg_ID.Add("12", "Kalimantan Selatan");
            cc_reg_ID.Add("13", "Kalimantan Tengah");
            cc_reg_ID.Add("14", "Kalimantan Timur");
            cc_reg_ID.Add("15", "Lampung");
            cc_reg_ID.Add("17", "Nusa Tenggara Barat");
            cc_reg_ID.Add("18", "Nusa Tenggara Timur");
            cc_reg_ID.Add("21", "Sulawesi Tengah");
            cc_reg_ID.Add("22", "Sulawesi Tenggara");
            cc_reg_ID.Add("24", "Sumatera Barat");
            cc_reg_ID.Add("26", "Sumatera Utara");
            cc_reg_ID.Add("28", "Maluku");
            cc_reg_ID.Add("29", "Maluku Utara");
            cc_reg_ID.Add("30", "Jawa Barat");
            cc_reg_ID.Add("31", "Sulawesi Utara");
            cc_reg_ID.Add("32", "Sumatera Selatan");
            cc_reg_ID.Add("33", "Banten");
            cc_reg_ID.Add("34", "Gorontalo");
            cc_reg_ID.Add("35", "Kepulauan Bangka Belitung");
            cc_reg_ID.Add("36", "Papua");
            cc_reg_ID.Add("37", "Riau");
            cc_reg_ID.Add("38", "Sulawesi Selatan");
            cc_reg_ID.Add("39", "Irian Jaya Barat");
            cc_reg_ID.Add("40", "Kepulauan Riau");
            cc_reg_ID.Add("41", "Sulawesi Barat");
            GEOIP_REGION_NAME.Add("ID", cc_reg_ID);
            Hashtable cc_reg_IE = new Hashtable();
            cc_reg_IE.Add("01", "Carlow");
            cc_reg_IE.Add("02", "Cavan");
            cc_reg_IE.Add("03", "Clare");
            cc_reg_IE.Add("04", "Cork");
            cc_reg_IE.Add("06", "Donegal");
            cc_reg_IE.Add("07", "Dublin");
            cc_reg_IE.Add("10", "Galway");
            cc_reg_IE.Add("11", "Kerry");
            cc_reg_IE.Add("12", "Kildare");
            cc_reg_IE.Add("13", "Kilkenny");
            cc_reg_IE.Add("14", "Leitrim");
            cc_reg_IE.Add("15", "Laois");
            cc_reg_IE.Add("16", "Limerick");
            cc_reg_IE.Add("18", "Longford");
            cc_reg_IE.Add("19", "Louth");
            cc_reg_IE.Add("20", "Mayo");
            cc_reg_IE.Add("21", "Meath");
            cc_reg_IE.Add("22", "Monaghan");
            cc_reg_IE.Add("23", "Offaly");
            cc_reg_IE.Add("24", "Roscommon");
            cc_reg_IE.Add("25", "Sligo");
            cc_reg_IE.Add("26", "Tipperary");
            cc_reg_IE.Add("27", "Waterford");
            cc_reg_IE.Add("29", "Westmeath");
            cc_reg_IE.Add("30", "Wexford");
            cc_reg_IE.Add("31", "Wicklow");
            GEOIP_REGION_NAME.Add("IE", cc_reg_IE);
            Hashtable cc_reg_IL = new Hashtable();
            cc_reg_IL.Add("01", "HaDarom");
            cc_reg_IL.Add("02", "HaMerkaz");
            cc_reg_IL.Add("03", "HaZafon");
            cc_reg_IL.Add("04", "Hefa");
            cc_reg_IL.Add("05", "Tel Aviv");
            cc_reg_IL.Add("06", "Yerushalayim");
            GEOIP_REGION_NAME.Add("IL", cc_reg_IL);
            Hashtable cc_reg_IN = new Hashtable();
            cc_reg_IN.Add("01", "Andaman and Nicobar Islands");
            cc_reg_IN.Add("02", "Andhra Pradesh");
            cc_reg_IN.Add("03", "Assam");
            cc_reg_IN.Add("05", "Chandigarh");
            cc_reg_IN.Add("06", "Dadra and Nagar Haveli");
            cc_reg_IN.Add("07", "Delhi");
            cc_reg_IN.Add("09", "Gujarat");
            cc_reg_IN.Add("10", "Haryana");
            cc_reg_IN.Add("11", "Himachal Pradesh");
            cc_reg_IN.Add("12", "Jammu and Kashmir");
            cc_reg_IN.Add("13", "Kerala");
            cc_reg_IN.Add("14", "Lakshadweep");
            cc_reg_IN.Add("16", "Maharashtra");
            cc_reg_IN.Add("17", "Manipur");
            cc_reg_IN.Add("18", "Meghalaya");
            cc_reg_IN.Add("19", "Karnataka");
            cc_reg_IN.Add("20", "Nagaland");
            cc_reg_IN.Add("21", "Orissa");
            cc_reg_IN.Add("22", "Puducherry");
            cc_reg_IN.Add("23", "Punjab");
            cc_reg_IN.Add("24", "Rajasthan");
            cc_reg_IN.Add("25", "Tamil Nadu");
            cc_reg_IN.Add("26", "Tripura");
            cc_reg_IN.Add("28", "West Bengal");
            cc_reg_IN.Add("29", "Sikkim");
            cc_reg_IN.Add("30", "Arunachal Pradesh");
            cc_reg_IN.Add("31", "Mizoram");
            cc_reg_IN.Add("32", "Daman and Diu");
            cc_reg_IN.Add("33", "Goa");
            cc_reg_IN.Add("34", "Bihar");
            cc_reg_IN.Add("35", "Madhya Pradesh");
            cc_reg_IN.Add("36", "Uttar Pradesh");
            cc_reg_IN.Add("37", "Chhattisgarh");
            cc_reg_IN.Add("38", "Jharkhand");
            cc_reg_IN.Add("39", "Uttarakhand");
            GEOIP_REGION_NAME.Add("IN", cc_reg_IN);
            Hashtable cc_reg_IQ = new Hashtable();
            cc_reg_IQ.Add("01", "Al Anbar");
            cc_reg_IQ.Add("02", "Al Basrah");
            cc_reg_IQ.Add("03", "Al Muthanna");
            cc_reg_IQ.Add("04", "Al Qadisiyah");
            cc_reg_IQ.Add("05", "As Sulaymaniyah");
            cc_reg_IQ.Add("06", "Babil");
            cc_reg_IQ.Add("07", "Baghdad");
            cc_reg_IQ.Add("08", "Dahuk");
            cc_reg_IQ.Add("09", "Dhi Qar");
            cc_reg_IQ.Add("10", "Diyala");
            cc_reg_IQ.Add("11", "Arbil");
            cc_reg_IQ.Add("12", "Karbala'");
            cc_reg_IQ.Add("13", "At Ta'mim");
            cc_reg_IQ.Add("14", "Maysan");
            cc_reg_IQ.Add("15", "Ninawa");
            cc_reg_IQ.Add("16", "Wasit");
            cc_reg_IQ.Add("17", "An Najaf");
            cc_reg_IQ.Add("18", "Salah ad Din");
            GEOIP_REGION_NAME.Add("IQ", cc_reg_IQ);
            Hashtable cc_reg_IR = new Hashtable();
            cc_reg_IR.Add("01", "Azarbayjan-e Bakhtari");
            cc_reg_IR.Add("03", "Chahar Mahall va Bakhtiari");
            cc_reg_IR.Add("04", "Sistan va Baluchestan");
            cc_reg_IR.Add("05", "Kohkiluyeh va Buyer Ahmadi");
            cc_reg_IR.Add("07", "Fars");
            cc_reg_IR.Add("08", "Gilan");
            cc_reg_IR.Add("09", "Hamadan");
            cc_reg_IR.Add("10", "Ilam");
            cc_reg_IR.Add("11", "Hormozgan");
            cc_reg_IR.Add("12", "Kerman");
            cc_reg_IR.Add("13", "Bakhtaran");
            cc_reg_IR.Add("15", "Khuzestan");
            cc_reg_IR.Add("16", "Kordestan");
            cc_reg_IR.Add("17", "Mazandaran");
            cc_reg_IR.Add("18", "Semnan Province");
            cc_reg_IR.Add("19", "Markazi");
            cc_reg_IR.Add("21", "Zanjan");
            cc_reg_IR.Add("22", "Bushehr");
            cc_reg_IR.Add("23", "Lorestan");
            cc_reg_IR.Add("24", "Markazi");
            cc_reg_IR.Add("25", "Semnan");
            cc_reg_IR.Add("26", "Tehran");
            cc_reg_IR.Add("27", "Zanjan");
            cc_reg_IR.Add("28", "Esfahan");
            cc_reg_IR.Add("29", "Kerman");
            cc_reg_IR.Add("30", "Khorasan");
            cc_reg_IR.Add("31", "Yazd");
            cc_reg_IR.Add("32", "Ardabil");
            cc_reg_IR.Add("33", "East Azarbaijan");
            cc_reg_IR.Add("34", "Markazi");
            cc_reg_IR.Add("35", "Mazandaran");
            cc_reg_IR.Add("36", "Zanjan");
            cc_reg_IR.Add("37", "Golestan");
            cc_reg_IR.Add("38", "Qazvin");
            cc_reg_IR.Add("39", "Qom");
            cc_reg_IR.Add("40", "Yazd");
            cc_reg_IR.Add("41", "Khorasan-e Janubi");
            cc_reg_IR.Add("42", "Khorasan-e Razavi");
            cc_reg_IR.Add("43", "Khorasan-e Shemali");
            cc_reg_IR.Add("44", "Alborz");
            GEOIP_REGION_NAME.Add("IR", cc_reg_IR);
            Hashtable cc_reg_IS = new Hashtable();
            cc_reg_IS.Add("03", "Arnessysla");
            cc_reg_IS.Add("05", "Austur-Hunavatnssysla");
            cc_reg_IS.Add("06", "Austur-Skaftafellssysla");
            cc_reg_IS.Add("07", "Borgarfjardarsysla");
            cc_reg_IS.Add("09", "Eyjafjardarsysla");
            cc_reg_IS.Add("10", "Gullbringusysla");
            cc_reg_IS.Add("15", "Kjosarsysla");
            cc_reg_IS.Add("17", "Myrasysla");
            cc_reg_IS.Add("20", "Nordur-Mulasysla");
            cc_reg_IS.Add("21", "Nordur-Tingeyjarsysla");
            cc_reg_IS.Add("23", "Rangarvallasysla");
            cc_reg_IS.Add("28", "Skagafjardarsysla");
            cc_reg_IS.Add("29", "Snafellsnes- og Hnappadalssysla");
            cc_reg_IS.Add("30", "Strandasysla");
            cc_reg_IS.Add("31", "Sudur-Mulasysla");
            cc_reg_IS.Add("32", "Sudur-Tingeyjarsysla");
            cc_reg_IS.Add("34", "Vestur-Bardastrandarsysla");
            cc_reg_IS.Add("35", "Vestur-Hunavatnssysla");
            cc_reg_IS.Add("36", "Vestur-Isafjardarsysla");
            cc_reg_IS.Add("37", "Vestur-Skaftafellssysla");
            cc_reg_IS.Add("38", "Austurland");
            cc_reg_IS.Add("39", "Hofuoborgarsvaoio");
            cc_reg_IS.Add("40", "Norourland Eystra");
            cc_reg_IS.Add("41", "Norourland Vestra");
            cc_reg_IS.Add("42", "Suourland");
            cc_reg_IS.Add("43", "Suournes");
            cc_reg_IS.Add("44", "Vestfiroir");
            cc_reg_IS.Add("45", "Vesturland");
            GEOIP_REGION_NAME.Add("IS", cc_reg_IS);
            Hashtable cc_reg_IT = new Hashtable();
            cc_reg_IT.Add("01", "Abruzzi");
            cc_reg_IT.Add("02", "Basilicata");
            cc_reg_IT.Add("03", "Calabria");
            cc_reg_IT.Add("04", "Campania");
            cc_reg_IT.Add("05", "Emilia-Romagna");
            cc_reg_IT.Add("06", "Friuli-Venezia Giulia");
            cc_reg_IT.Add("07", "Lazio");
            cc_reg_IT.Add("08", "Liguria");
            cc_reg_IT.Add("09", "Lombardia");
            cc_reg_IT.Add("10", "Marche");
            cc_reg_IT.Add("11", "Molise");
            cc_reg_IT.Add("12", "Piemonte");
            cc_reg_IT.Add("13", "Puglia");
            cc_reg_IT.Add("14", "Sardegna");
            cc_reg_IT.Add("15", "Sicilia");
            cc_reg_IT.Add("16", "Toscana");
            cc_reg_IT.Add("17", "Trentino-Alto Adige");
            cc_reg_IT.Add("18", "Umbria");
            cc_reg_IT.Add("19", "Valle d'Aosta");
            cc_reg_IT.Add("20", "Veneto");
            GEOIP_REGION_NAME.Add("IT", cc_reg_IT);
            Hashtable cc_reg_JM = new Hashtable();
            cc_reg_JM.Add("01", "Clarendon");
            cc_reg_JM.Add("02", "Hanover");
            cc_reg_JM.Add("04", "Manchester");
            cc_reg_JM.Add("07", "Portland");
            cc_reg_JM.Add("08", "Saint Andrew");
            cc_reg_JM.Add("09", "Saint Ann");
            cc_reg_JM.Add("10", "Saint Catherine");
            cc_reg_JM.Add("11", "Saint Elizabeth");
            cc_reg_JM.Add("12", "Saint James");
            cc_reg_JM.Add("13", "Saint Mary");
            cc_reg_JM.Add("14", "Saint Thomas");
            cc_reg_JM.Add("15", "Trelawny");
            cc_reg_JM.Add("16", "Westmoreland");
            cc_reg_JM.Add("17", "Kingston");
            GEOIP_REGION_NAME.Add("JM", cc_reg_JM);
            Hashtable cc_reg_JO = new Hashtable();
            cc_reg_JO.Add("02", "Al Balqa'");
            cc_reg_JO.Add("09", "Al Karak");
            cc_reg_JO.Add("12", "At Tafilah");
            cc_reg_JO.Add("15", "Al Mafraq");
            cc_reg_JO.Add("16", "Amman");
            cc_reg_JO.Add("17", "Az Zaraqa");
            cc_reg_JO.Add("18", "Irbid");
            cc_reg_JO.Add("19", "Ma'an");
            cc_reg_JO.Add("20", "Ajlun");
            cc_reg_JO.Add("21", "Al Aqabah");
            cc_reg_JO.Add("22", "Jarash");
            cc_reg_JO.Add("23", "Madaba");
            GEOIP_REGION_NAME.Add("JO", cc_reg_JO);
            Hashtable cc_reg_JP = new Hashtable();
            cc_reg_JP.Add("01", "Aichi");
            cc_reg_JP.Add("02", "Akita");
            cc_reg_JP.Add("03", "Aomori");
            cc_reg_JP.Add("04", "Chiba");
            cc_reg_JP.Add("05", "Ehime");
            cc_reg_JP.Add("06", "Fukui");
            cc_reg_JP.Add("07", "Fukuoka");
            cc_reg_JP.Add("08", "Fukushima");
            cc_reg_JP.Add("09", "Gifu");
            cc_reg_JP.Add("10", "Gumma");
            cc_reg_JP.Add("11", "Hiroshima");
            cc_reg_JP.Add("12", "Hokkaido");
            cc_reg_JP.Add("13", "Hyogo");
            cc_reg_JP.Add("14", "Ibaraki");
            cc_reg_JP.Add("15", "Ishikawa");
            cc_reg_JP.Add("16", "Iwate");
            cc_reg_JP.Add("17", "Kagawa");
            cc_reg_JP.Add("18", "Kagoshima");
            cc_reg_JP.Add("19", "Kanagawa");
            cc_reg_JP.Add("20", "Kochi");
            cc_reg_JP.Add("21", "Kumamoto");
            cc_reg_JP.Add("22", "Kyoto");
            cc_reg_JP.Add("23", "Mie");
            cc_reg_JP.Add("24", "Miyagi");
            cc_reg_JP.Add("25", "Miyazaki");
            cc_reg_JP.Add("26", "Nagano");
            cc_reg_JP.Add("27", "Nagasaki");
            cc_reg_JP.Add("28", "Nara");
            cc_reg_JP.Add("29", "Niigata");
            cc_reg_JP.Add("30", "Oita");
            cc_reg_JP.Add("31", "Okayama");
            cc_reg_JP.Add("32", "Osaka");
            cc_reg_JP.Add("33", "Saga");
            cc_reg_JP.Add("34", "Saitama");
            cc_reg_JP.Add("35", "Shiga");
            cc_reg_JP.Add("36", "Shimane");
            cc_reg_JP.Add("37", "Shizuoka");
            cc_reg_JP.Add("38", "Tochigi");
            cc_reg_JP.Add("39", "Tokushima");
            cc_reg_JP.Add("40", "Tokyo");
            cc_reg_JP.Add("41", "Tottori");
            cc_reg_JP.Add("42", "Toyama");
            cc_reg_JP.Add("43", "Wakayama");
            cc_reg_JP.Add("44", "Yamagata");
            cc_reg_JP.Add("45", "Yamaguchi");
            cc_reg_JP.Add("46", "Yamanashi");
            cc_reg_JP.Add("47", "Okinawa");
            GEOIP_REGION_NAME.Add("JP", cc_reg_JP);
            Hashtable cc_reg_KE = new Hashtable();
            cc_reg_KE.Add("01", "Central");
            cc_reg_KE.Add("02", "Coast");
            cc_reg_KE.Add("03", "Eastern");
            cc_reg_KE.Add("05", "Nairobi Area");
            cc_reg_KE.Add("06", "North-Eastern");
            cc_reg_KE.Add("07", "Nyanza");
            cc_reg_KE.Add("08", "Rift Valley");
            cc_reg_KE.Add("09", "Western");
            GEOIP_REGION_NAME.Add("KE", cc_reg_KE);
            Hashtable cc_reg_KG = new Hashtable();
            cc_reg_KG.Add("01", "Bishkek");
            cc_reg_KG.Add("02", "Chuy");
            cc_reg_KG.Add("03", "Jalal-Abad");
            cc_reg_KG.Add("04", "Naryn");
            cc_reg_KG.Add("05", "Osh");
            cc_reg_KG.Add("06", "Talas");
            cc_reg_KG.Add("07", "Ysyk-Kol");
            cc_reg_KG.Add("08", "Osh");
            cc_reg_KG.Add("09", "Batken");
            GEOIP_REGION_NAME.Add("KG", cc_reg_KG);
            Hashtable cc_reg_KH = new Hashtable();
            cc_reg_KH.Add("01", "Batdambang");
            cc_reg_KH.Add("02", "Kampong Cham");
            cc_reg_KH.Add("03", "Kampong Chhnang");
            cc_reg_KH.Add("04", "Kampong Speu");
            cc_reg_KH.Add("05", "Kampong Thum");
            cc_reg_KH.Add("06", "Kampot");
            cc_reg_KH.Add("07", "Kandal");
            cc_reg_KH.Add("08", "Koh Kong");
            cc_reg_KH.Add("09", "Kracheh");
            cc_reg_KH.Add("10", "Mondulkiri");
            cc_reg_KH.Add("11", "Phnum Penh");
            cc_reg_KH.Add("12", "Pursat");
            cc_reg_KH.Add("13", "Preah Vihear");
            cc_reg_KH.Add("14", "Prey Veng");
            cc_reg_KH.Add("15", "Ratanakiri Kiri");
            cc_reg_KH.Add("16", "Siem Reap");
            cc_reg_KH.Add("17", "Stung Treng");
            cc_reg_KH.Add("18", "Svay Rieng");
            cc_reg_KH.Add("19", "Takeo");
            cc_reg_KH.Add("25", "Banteay Meanchey");
            cc_reg_KH.Add("29", "Batdambang");
            cc_reg_KH.Add("30", "Pailin");
            GEOIP_REGION_NAME.Add("KH", cc_reg_KH);
            Hashtable cc_reg_KI = new Hashtable();
            cc_reg_KI.Add("01", "Gilbert Islands");
            cc_reg_KI.Add("02", "Line Islands");
            cc_reg_KI.Add("03", "Phoenix Islands");
            GEOIP_REGION_NAME.Add("KI", cc_reg_KI);
            Hashtable cc_reg_KM = new Hashtable();
            cc_reg_KM.Add("01", "Anjouan");
            cc_reg_KM.Add("02", "Grande Comore");
            cc_reg_KM.Add("03", "Moheli");
            GEOIP_REGION_NAME.Add("KM", cc_reg_KM);
            Hashtable cc_reg_KN = new Hashtable();
            cc_reg_KN.Add("01", "Christ Church Nichola Town");
            cc_reg_KN.Add("02", "Saint Anne Sandy Point");
            cc_reg_KN.Add("03", "Saint George Basseterre");
            cc_reg_KN.Add("04", "Saint George Gingerland");
            cc_reg_KN.Add("05", "Saint James Windward");
            cc_reg_KN.Add("06", "Saint John Capisterre");
            cc_reg_KN.Add("07", "Saint John Figtree");
            cc_reg_KN.Add("08", "Saint Mary Cayon");
            cc_reg_KN.Add("09", "Saint Paul Capisterre");
            cc_reg_KN.Add("10", "Saint Paul Charlestown");
            cc_reg_KN.Add("11", "Saint Peter Basseterre");
            cc_reg_KN.Add("12", "Saint Thomas Lowland");
            cc_reg_KN.Add("13", "Saint Thomas Middle Island");
            cc_reg_KN.Add("15", "Trinity Palmetto Point");
            GEOIP_REGION_NAME.Add("KN", cc_reg_KN);
            Hashtable cc_reg_KP = new Hashtable();
            cc_reg_KP.Add("01", "Chagang-do");
            cc_reg_KP.Add("03", "Hamgyong-namdo");
            cc_reg_KP.Add("06", "Hwanghae-namdo");
            cc_reg_KP.Add("07", "Hwanghae-bukto");
            cc_reg_KP.Add("08", "Kaesong-si");
            cc_reg_KP.Add("09", "Kangwon-do");
            cc_reg_KP.Add("11", "P'yongan-bukto");
            cc_reg_KP.Add("12", "P'yongyang-si");
            cc_reg_KP.Add("13", "Yanggang-do");
            cc_reg_KP.Add("14", "Namp'o-si");
            cc_reg_KP.Add("15", "P'yongan-namdo");
            cc_reg_KP.Add("17", "Hamgyong-bukto");
            cc_reg_KP.Add("18", "Najin Sonbong-si");
            GEOIP_REGION_NAME.Add("KP", cc_reg_KP);
            Hashtable cc_reg_KR = new Hashtable();
            cc_reg_KR.Add("01", "Cheju-do");
            cc_reg_KR.Add("03", "Cholla-bukto");
            cc_reg_KR.Add("05", "Ch'ungch'ong-bukto");
            cc_reg_KR.Add("06", "Kangwon-do");
            cc_reg_KR.Add("10", "Pusan-jikhalsi");
            cc_reg_KR.Add("11", "Seoul-t'ukpyolsi");
            cc_reg_KR.Add("12", "Inch'on-jikhalsi");
            cc_reg_KR.Add("13", "Kyonggi-do");
            cc_reg_KR.Add("14", "Kyongsang-bukto");
            cc_reg_KR.Add("15", "Taegu-jikhalsi");
            cc_reg_KR.Add("16", "Cholla-namdo");
            cc_reg_KR.Add("17", "Ch'ungch'ong-namdo");
            cc_reg_KR.Add("18", "Kwangju-jikhalsi");
            cc_reg_KR.Add("19", "Taejon-jikhalsi");
            cc_reg_KR.Add("20", "Kyongsang-namdo");
            cc_reg_KR.Add("21", "Ulsan-gwangyoksi");
            GEOIP_REGION_NAME.Add("KR", cc_reg_KR);
            Hashtable cc_reg_KW = new Hashtable();
            cc_reg_KW.Add("01", "Al Ahmadi");
            cc_reg_KW.Add("02", "Al Kuwayt");
            cc_reg_KW.Add("05", "Al Jahra");
            cc_reg_KW.Add("07", "Al Farwaniyah");
            cc_reg_KW.Add("08", "Hawalli");
            cc_reg_KW.Add("09", "Mubarak al Kabir");
            GEOIP_REGION_NAME.Add("KW", cc_reg_KW);
            Hashtable cc_reg_KY = new Hashtable();
            cc_reg_KY.Add("01", "Creek");
            cc_reg_KY.Add("02", "Eastern");
            cc_reg_KY.Add("03", "Midland");
            cc_reg_KY.Add("04", "South Town");
            cc_reg_KY.Add("05", "Spot Bay");
            cc_reg_KY.Add("06", "Stake Bay");
            cc_reg_KY.Add("07", "West End");
            cc_reg_KY.Add("08", "Western");
            GEOIP_REGION_NAME.Add("KY", cc_reg_KY);
            Hashtable cc_reg_KZ = new Hashtable();
            cc_reg_KZ.Add("01", "Almaty");
            cc_reg_KZ.Add("02", "Almaty City");
            cc_reg_KZ.Add("03", "Aqmola");
            cc_reg_KZ.Add("04", "Aqtobe");
            cc_reg_KZ.Add("05", "Astana");
            cc_reg_KZ.Add("06", "Atyrau");
            cc_reg_KZ.Add("07", "West Kazakhstan");
            cc_reg_KZ.Add("08", "Bayqonyr");
            cc_reg_KZ.Add("09", "Mangghystau");
            cc_reg_KZ.Add("10", "South Kazakhstan");
            cc_reg_KZ.Add("11", "Pavlodar");
            cc_reg_KZ.Add("12", "Qaraghandy");
            cc_reg_KZ.Add("13", "Qostanay");
            cc_reg_KZ.Add("14", "Qyzylorda");
            cc_reg_KZ.Add("15", "East Kazakhstan");
            cc_reg_KZ.Add("16", "North Kazakhstan");
            cc_reg_KZ.Add("17", "Zhambyl");
            GEOIP_REGION_NAME.Add("KZ", cc_reg_KZ);
            Hashtable cc_reg_LA = new Hashtable();
            cc_reg_LA.Add("01", "Attapu");
            cc_reg_LA.Add("02", "Champasak");
            cc_reg_LA.Add("03", "Houaphan");
            cc_reg_LA.Add("04", "Khammouan");
            cc_reg_LA.Add("05", "Louang Namtha");
            cc_reg_LA.Add("07", "Oudomxai");
            cc_reg_LA.Add("08", "Phongsali");
            cc_reg_LA.Add("09", "Saravan");
            cc_reg_LA.Add("10", "Savannakhet");
            cc_reg_LA.Add("11", "Vientiane");
            cc_reg_LA.Add("13", "Xaignabouri");
            cc_reg_LA.Add("14", "Xiangkhoang");
            cc_reg_LA.Add("17", "Louangphrabang");
            GEOIP_REGION_NAME.Add("LA", cc_reg_LA);
            Hashtable cc_reg_LB = new Hashtable();
            cc_reg_LB.Add("01", "Beqaa");
            cc_reg_LB.Add("02", "Al Janub");
            cc_reg_LB.Add("03", "Liban-Nord");
            cc_reg_LB.Add("04", "Beyrouth");
            cc_reg_LB.Add("05", "Mont-Liban");
            cc_reg_LB.Add("06", "Liban-Sud");
            cc_reg_LB.Add("07", "Nabatiye");
            cc_reg_LB.Add("08", "Beqaa");
            cc_reg_LB.Add("09", "Liban-Nord");
            cc_reg_LB.Add("10", "Aakk,r");
            cc_reg_LB.Add("11", "Baalbek-Hermel");
            GEOIP_REGION_NAME.Add("LB", cc_reg_LB);
            Hashtable cc_reg_LC = new Hashtable();
            cc_reg_LC.Add("01", "Anse-la-Raye");
            cc_reg_LC.Add("02", "Dauphin");
            cc_reg_LC.Add("03", "Castries");
            cc_reg_LC.Add("04", "Choiseul");
            cc_reg_LC.Add("05", "Dennery");
            cc_reg_LC.Add("06", "Gros-Islet");
            cc_reg_LC.Add("07", "Laborie");
            cc_reg_LC.Add("08", "Micoud");
            cc_reg_LC.Add("09", "Soufriere");
            cc_reg_LC.Add("10", "Vieux-Fort");
            cc_reg_LC.Add("11", "Praslin");
            GEOIP_REGION_NAME.Add("LC", cc_reg_LC);
            Hashtable cc_reg_LI = new Hashtable();
            cc_reg_LI.Add("01", "Balzers");
            cc_reg_LI.Add("02", "Eschen");
            cc_reg_LI.Add("03", "Gamprin");
            cc_reg_LI.Add("04", "Mauren");
            cc_reg_LI.Add("05", "Planken");
            cc_reg_LI.Add("06", "Ruggell");
            cc_reg_LI.Add("07", "Schaan");
            cc_reg_LI.Add("08", "Schellenberg");
            cc_reg_LI.Add("09", "Triesen");
            cc_reg_LI.Add("10", "Triesenberg");
            cc_reg_LI.Add("11", "Vaduz");
            cc_reg_LI.Add("21", "Gbarpolu");
            cc_reg_LI.Add("22", "River Gee");
            GEOIP_REGION_NAME.Add("LI", cc_reg_LI);
            Hashtable cc_reg_LK = new Hashtable();
            cc_reg_LK.Add("29", "Central");
            cc_reg_LK.Add("30", "North Central");
            cc_reg_LK.Add("32", "North Western");
            cc_reg_LK.Add("33", "Sabaragamuwa");
            cc_reg_LK.Add("34", "Southern");
            cc_reg_LK.Add("35", "Uva");
            cc_reg_LK.Add("36", "Western");
            cc_reg_LK.Add("37", "Eastern");
            cc_reg_LK.Add("38", "Northern");
            GEOIP_REGION_NAME.Add("LK", cc_reg_LK);
            Hashtable cc_reg_LR = new Hashtable();
            cc_reg_LR.Add("01", "Bong");
            cc_reg_LR.Add("04", "Grand Cape Mount");
            cc_reg_LR.Add("05", "Lofa");
            cc_reg_LR.Add("06", "Maryland");
            cc_reg_LR.Add("07", "Monrovia");
            cc_reg_LR.Add("09", "Nimba");
            cc_reg_LR.Add("10", "Sino");
            cc_reg_LR.Add("11", "Grand Bassa");
            cc_reg_LR.Add("12", "Grand Cape Mount");
            cc_reg_LR.Add("13", "Maryland");
            cc_reg_LR.Add("14", "Montserrado");
            cc_reg_LR.Add("17", "Margibi");
            cc_reg_LR.Add("18", "River Cess");
            cc_reg_LR.Add("19", "Grand Gedeh");
            cc_reg_LR.Add("20", "Lofa");
            cc_reg_LR.Add("21", "Gbarpolu");
            cc_reg_LR.Add("22", "River Gee");
            GEOIP_REGION_NAME.Add("LR", cc_reg_LR);
            Hashtable cc_reg_LS = new Hashtable();
            cc_reg_LS.Add("10", "Berea");
            cc_reg_LS.Add("11", "Butha-Buthe");
            cc_reg_LS.Add("12", "Leribe");
            cc_reg_LS.Add("13", "Mafeteng");
            cc_reg_LS.Add("14", "Maseru");
            cc_reg_LS.Add("15", "Mohales Hoek");
            cc_reg_LS.Add("16", "Mokhotlong");
            cc_reg_LS.Add("17", "Qachas Nek");
            cc_reg_LS.Add("18", "Quthing");
            cc_reg_LS.Add("19", "Thaba-Tseka");
            GEOIP_REGION_NAME.Add("LS", cc_reg_LS);
            Hashtable cc_reg_LT = new Hashtable();
            cc_reg_LT.Add("56", "Alytaus Apskritis");
            cc_reg_LT.Add("57", "Kauno Apskritis");
            cc_reg_LT.Add("58", "Klaipedos Apskritis");
            cc_reg_LT.Add("59", "Marijampoles Apskritis");
            cc_reg_LT.Add("60", "Panevezio Apskritis");
            cc_reg_LT.Add("61", "Siauliu Apskritis");
            cc_reg_LT.Add("62", "Taurages Apskritis");
            cc_reg_LT.Add("63", "Telsiu Apskritis");
            cc_reg_LT.Add("64", "Utenos Apskritis");
            cc_reg_LT.Add("65", "Vilniaus Apskritis");
            GEOIP_REGION_NAME.Add("LT", cc_reg_LT);
            Hashtable cc_reg_LU = new Hashtable();
            cc_reg_LU.Add("01", "Diekirch");
            cc_reg_LU.Add("02", "Grevenmacher");
            cc_reg_LU.Add("03", "Luxembourg");
            GEOIP_REGION_NAME.Add("LU", cc_reg_LU);
            Hashtable cc_reg_LV = new Hashtable();
            cc_reg_LV.Add("01", "Aizkraukles");
            cc_reg_LV.Add("02", "Aluksnes");
            cc_reg_LV.Add("03", "Balvu");
            cc_reg_LV.Add("04", "Bauskas");
            cc_reg_LV.Add("05", "Cesu");
            cc_reg_LV.Add("06", "Daugavpils");
            cc_reg_LV.Add("07", "Daugavpils");
            cc_reg_LV.Add("08", "Dobeles");
            cc_reg_LV.Add("09", "Gulbenes");
            cc_reg_LV.Add("10", "Jekabpils");
            cc_reg_LV.Add("11", "Jelgava");
            cc_reg_LV.Add("12", "Jelgavas");
            cc_reg_LV.Add("13", "Jurmala");
            cc_reg_LV.Add("14", "Kraslavas");
            cc_reg_LV.Add("15", "Kuldigas");
            cc_reg_LV.Add("16", "Liepaja");
            cc_reg_LV.Add("17", "Liepajas");
            cc_reg_LV.Add("18", "Limbazu");
            cc_reg_LV.Add("19", "Ludzas");
            cc_reg_LV.Add("20", "Madonas");
            cc_reg_LV.Add("21", "Ogres");
            cc_reg_LV.Add("22", "Preilu");
            cc_reg_LV.Add("23", "Rezekne");
            cc_reg_LV.Add("24", "Rezeknes");
            cc_reg_LV.Add("25", "Riga");
            cc_reg_LV.Add("26", "Rigas");
            cc_reg_LV.Add("27", "Saldus");
            cc_reg_LV.Add("28", "Talsu");
            cc_reg_LV.Add("29", "Tukuma");
            cc_reg_LV.Add("30", "Valkas");
            cc_reg_LV.Add("31", "Valmieras");
            cc_reg_LV.Add("32", "Ventspils");
            cc_reg_LV.Add("33", "Ventspils");
            GEOIP_REGION_NAME.Add("LV", cc_reg_LV);
            Hashtable cc_reg_LY = new Hashtable();
            cc_reg_LY.Add("03", "Al Aziziyah");
            cc_reg_LY.Add("05", "Al Jufrah");
            cc_reg_LY.Add("08", "Al Kufrah");
            cc_reg_LY.Add("13", "Ash Shati'");
            cc_reg_LY.Add("30", "Murzuq");
            cc_reg_LY.Add("34", "Sabha");
            cc_reg_LY.Add("41", "Tarhunah");
            cc_reg_LY.Add("42", "Tubruq");
            cc_reg_LY.Add("45", "Zlitan");
            cc_reg_LY.Add("47", "Ajdabiya");
            cc_reg_LY.Add("48", "Al Fatih");
            cc_reg_LY.Add("49", "Al Jabal al Akhdar");
            cc_reg_LY.Add("50", "Al Khums");
            cc_reg_LY.Add("51", "An Nuqat al Khams");
            cc_reg_LY.Add("52", "Awbari");
            cc_reg_LY.Add("53", "Az Zawiyah");
            cc_reg_LY.Add("54", "Banghazi");
            cc_reg_LY.Add("55", "Darnah");
            cc_reg_LY.Add("56", "Ghadamis");
            cc_reg_LY.Add("57", "Gharyan");
            cc_reg_LY.Add("58", "Misratah");
            cc_reg_LY.Add("59", "Sawfajjin");
            cc_reg_LY.Add("60", "Surt");
            cc_reg_LY.Add("61", "Tarabulus");
            cc_reg_LY.Add("62", "Yafran");
            GEOIP_REGION_NAME.Add("LY", cc_reg_LY);
            Hashtable cc_reg_MA = new Hashtable();
            cc_reg_MA.Add("45", "Grand Casablanca");
            cc_reg_MA.Add("46", "Fes-Boulemane");
            cc_reg_MA.Add("47", "Marrakech-Tensift-Al Haouz");
            cc_reg_MA.Add("48", "Meknes-Tafilalet");
            cc_reg_MA.Add("49", "Rabat-Sale-Zemmour-Zaer");
            cc_reg_MA.Add("50", "Chaouia-Ouardigha");
            cc_reg_MA.Add("51", "Doukkala-Abda");
            cc_reg_MA.Add("52", "Gharb-Chrarda-Beni Hssen");
            cc_reg_MA.Add("53", "Guelmim-Es Smara");
            cc_reg_MA.Add("54", "Oriental");
            cc_reg_MA.Add("55", "Souss-Massa-Dr,a");
            cc_reg_MA.Add("56", "Tadla-Azilal");
            cc_reg_MA.Add("57", "Tanger-Tetouan");
            cc_reg_MA.Add("58", "Taza-Al Hoceima-Taounate");
            cc_reg_MA.Add("59", "La,youne-Boujdour-Sakia El Hamra");
            GEOIP_REGION_NAME.Add("MA", cc_reg_MA);
            Hashtable cc_reg_MC = new Hashtable();
            cc_reg_MC.Add("01", "La Condamine");
            cc_reg_MC.Add("02", "Monaco");
            cc_reg_MC.Add("03", "Monte-Carlo");
            GEOIP_REGION_NAME.Add("MC", cc_reg_MC);
            Hashtable cc_reg_MD = new Hashtable();
            cc_reg_MD.Add("51", "Gagauzia");
            cc_reg_MD.Add("57", "Chisinau");
            cc_reg_MD.Add("58", "Stinga Nistrului");
            cc_reg_MD.Add("59", "Anenii Noi");
            cc_reg_MD.Add("60", "Balti");
            cc_reg_MD.Add("61", "Basarabeasca");
            cc_reg_MD.Add("62", "Bender");
            cc_reg_MD.Add("63", "Briceni");
            cc_reg_MD.Add("64", "Cahul");
            cc_reg_MD.Add("65", "Cantemir");
            cc_reg_MD.Add("66", "Calarasi");
            cc_reg_MD.Add("67", "Causeni");
            cc_reg_MD.Add("68", "Cimislia");
            cc_reg_MD.Add("69", "Criuleni");
            cc_reg_MD.Add("70", "Donduseni");
            cc_reg_MD.Add("71", "Drochia");
            cc_reg_MD.Add("72", "Dubasari");
            cc_reg_MD.Add("73", "Edinet");
            cc_reg_MD.Add("74", "Falesti");
            cc_reg_MD.Add("75", "Floresti");
            cc_reg_MD.Add("76", "Glodeni");
            cc_reg_MD.Add("77", "Hincesti");
            cc_reg_MD.Add("78", "Ialoveni");
            cc_reg_MD.Add("79", "Leova");
            cc_reg_MD.Add("80", "Nisporeni");
            cc_reg_MD.Add("81", "Ocnita");
            cc_reg_MD.Add("82", "Orhei");
            cc_reg_MD.Add("83", "Rezina");
            cc_reg_MD.Add("84", "Riscani");
            cc_reg_MD.Add("85", "Singerei");
            cc_reg_MD.Add("86", "Soldanesti");
            cc_reg_MD.Add("87", "Soroca");
            cc_reg_MD.Add("88", "Stefan-Voda");
            cc_reg_MD.Add("89", "Straseni");
            cc_reg_MD.Add("90", "Taraclia");
            cc_reg_MD.Add("91", "Telenesti");
            cc_reg_MD.Add("92", "Ungheni");
            GEOIP_REGION_NAME.Add("MD", cc_reg_MD);
            Hashtable cc_reg_MG = new Hashtable();
            cc_reg_MG.Add("01", "Antsiranana");
            cc_reg_MG.Add("02", "Fianarantsoa");
            cc_reg_MG.Add("03", "Mahajanga");
            cc_reg_MG.Add("04", "Toamasina");
            cc_reg_MG.Add("05", "Antananarivo");
            cc_reg_MG.Add("06", "Toliara");
            GEOIP_REGION_NAME.Add("MG", cc_reg_MG);
            Hashtable cc_reg_MK = new Hashtable();
            cc_reg_MK.Add("01", "Aracinovo");
            cc_reg_MK.Add("02", "Bac");
            cc_reg_MK.Add("03", "Belcista");
            cc_reg_MK.Add("04", "Berovo");
            cc_reg_MK.Add("05", "Bistrica");
            cc_reg_MK.Add("06", "Bitola");
            cc_reg_MK.Add("07", "Blatec");
            cc_reg_MK.Add("08", "Bogdanci");
            cc_reg_MK.Add("09", "Bogomila");
            cc_reg_MK.Add("10", "Bogovinje");
            cc_reg_MK.Add("11", "Bosilovo");
            cc_reg_MK.Add("12", "Brvenica");
            cc_reg_MK.Add("13", "Cair");
            cc_reg_MK.Add("14", "Capari");
            cc_reg_MK.Add("15", "Caska");
            cc_reg_MK.Add("16", "Cegrane");
            cc_reg_MK.Add("17", "Centar");
            cc_reg_MK.Add("18", "Centar Zupa");
            cc_reg_MK.Add("19", "Cesinovo");
            cc_reg_MK.Add("20", "Cucer-Sandevo");
            cc_reg_MK.Add("21", "Debar");
            cc_reg_MK.Add("22", "Delcevo");
            cc_reg_MK.Add("23", "Delogozdi");
            cc_reg_MK.Add("24", "Demir Hisar");
            cc_reg_MK.Add("25", "Demir Kapija");
            cc_reg_MK.Add("26", "Dobrusevo");
            cc_reg_MK.Add("27", "Dolna Banjica");
            cc_reg_MK.Add("28", "Dolneni");
            cc_reg_MK.Add("29", "Dorce Petrov");
            cc_reg_MK.Add("30", "Drugovo");
            cc_reg_MK.Add("31", "Dzepciste");
            cc_reg_MK.Add("32", "Gazi Baba");
            cc_reg_MK.Add("33", "Gevgelija");
            cc_reg_MK.Add("34", "Gostivar");
            cc_reg_MK.Add("35", "Gradsko");
            cc_reg_MK.Add("36", "Ilinden");
            cc_reg_MK.Add("37", "Izvor");
            cc_reg_MK.Add("38", "Jegunovce");
            cc_reg_MK.Add("39", "Kamenjane");
            cc_reg_MK.Add("40", "Karbinci");
            cc_reg_MK.Add("41", "Karpos");
            cc_reg_MK.Add("42", "Kavadarci");
            cc_reg_MK.Add("43", "Kicevo");
            cc_reg_MK.Add("44", "Kisela Voda");
            cc_reg_MK.Add("45", "Klecevce");
            cc_reg_MK.Add("46", "Kocani");
            cc_reg_MK.Add("47", "Konce");
            cc_reg_MK.Add("48", "Kondovo");
            cc_reg_MK.Add("49", "Konopiste");
            cc_reg_MK.Add("50", "Kosel");
            cc_reg_MK.Add("51", "Kratovo");
            cc_reg_MK.Add("52", "Kriva Palanka");
            cc_reg_MK.Add("53", "Krivogastani");
            cc_reg_MK.Add("54", "Krusevo");
            cc_reg_MK.Add("55", "Kuklis");
            cc_reg_MK.Add("56", "Kukurecani");
            cc_reg_MK.Add("57", "Kumanovo");
            cc_reg_MK.Add("58", "Labunista");
            cc_reg_MK.Add("59", "Lipkovo");
            cc_reg_MK.Add("60", "Lozovo");
            cc_reg_MK.Add("61", "Lukovo");
            cc_reg_MK.Add("62", "Makedonska Kamenica");
            cc_reg_MK.Add("63", "Makedonski Brod");
            cc_reg_MK.Add("64", "Mavrovi Anovi");
            cc_reg_MK.Add("65", "Meseista");
            cc_reg_MK.Add("66", "Miravci");
            cc_reg_MK.Add("67", "Mogila");
            cc_reg_MK.Add("68", "Murtino");
            cc_reg_MK.Add("69", "Negotino");
            cc_reg_MK.Add("70", "Negotino-Polosko");
            cc_reg_MK.Add("71", "Novaci");
            cc_reg_MK.Add("72", "Novo Selo");
            cc_reg_MK.Add("73", "Oblesevo");
            cc_reg_MK.Add("74", "Ohrid");
            cc_reg_MK.Add("75", "Orasac");
            cc_reg_MK.Add("76", "Orizari");
            cc_reg_MK.Add("77", "Oslomej");
            cc_reg_MK.Add("78", "Pehcevo");
            cc_reg_MK.Add("79", "Petrovec");
            cc_reg_MK.Add("80", "Plasnica");
            cc_reg_MK.Add("81", "Podares");
            cc_reg_MK.Add("82", "Prilep");
            cc_reg_MK.Add("83", "Probistip");
            cc_reg_MK.Add("84", "Radovis");
            cc_reg_MK.Add("85", "Rankovce");
            cc_reg_MK.Add("86", "Resen");
            cc_reg_MK.Add("87", "Rosoman");
            cc_reg_MK.Add("88", "Rostusa");
            cc_reg_MK.Add("89", "Samokov");
            cc_reg_MK.Add("90", "Saraj");
            cc_reg_MK.Add("91", "Sipkovica");
            cc_reg_MK.Add("92", "Sopiste");
            cc_reg_MK.Add("93", "Sopotnica");
            cc_reg_MK.Add("94", "Srbinovo");
            cc_reg_MK.Add("95", "Staravina");
            cc_reg_MK.Add("96", "Star Dojran");
            cc_reg_MK.Add("97", "Staro Nagoricane");
            cc_reg_MK.Add("98", "Stip");
            cc_reg_MK.Add("99", "Struga");
            cc_reg_MK.Add("A1", "Strumica");
            cc_reg_MK.Add("A2", "Studenicani");
            cc_reg_MK.Add("A3", "Suto Orizari");
            cc_reg_MK.Add("A4", "Sveti Nikole");
            cc_reg_MK.Add("A5", "Tearce");
            cc_reg_MK.Add("A6", "Tetovo");
            cc_reg_MK.Add("A7", "Topolcani");
            cc_reg_MK.Add("A8", "Valandovo");
            cc_reg_MK.Add("A9", "Vasilevo");
            cc_reg_MK.Add("B1", "Veles");
            cc_reg_MK.Add("B2", "Velesta");
            cc_reg_MK.Add("B3", "Vevcani");
            cc_reg_MK.Add("B4", "Vinica");
            cc_reg_MK.Add("B5", "Vitoliste");
            cc_reg_MK.Add("B6", "Vranestica");
            cc_reg_MK.Add("B7", "Vrapciste");
            cc_reg_MK.Add("B8", "Vratnica");
            cc_reg_MK.Add("B9", "Vrutok");
            cc_reg_MK.Add("C1", "Zajas");
            cc_reg_MK.Add("C2", "Zelenikovo");
            cc_reg_MK.Add("C3", "Zelino");
            cc_reg_MK.Add("C4", "Zitose");
            cc_reg_MK.Add("C5", "Zletovo");
            cc_reg_MK.Add("C6", "Zrnovci");
            GEOIP_REGION_NAME.Add("MK", cc_reg_MK);
            Hashtable cc_reg_ML = new Hashtable();
            cc_reg_ML.Add("01", "Bamako");
            cc_reg_ML.Add("03", "Kayes");
            cc_reg_ML.Add("04", "Mopti");
            cc_reg_ML.Add("05", "Segou");
            cc_reg_ML.Add("06", "Sikasso");
            cc_reg_ML.Add("07", "Koulikoro");
            cc_reg_ML.Add("08", "Tombouctou");
            cc_reg_ML.Add("09", "Gao");
            cc_reg_ML.Add("10", "Kidal");
            GEOIP_REGION_NAME.Add("ML", cc_reg_ML);
            Hashtable cc_reg_MM = new Hashtable();
            cc_reg_MM.Add("01", "Rakhine State");
            cc_reg_MM.Add("02", "Chin State");
            cc_reg_MM.Add("03", "Irrawaddy");
            cc_reg_MM.Add("04", "Kachin State");
            cc_reg_MM.Add("05", "Karan State");
            cc_reg_MM.Add("06", "Kayah State");
            cc_reg_MM.Add("07", "Magwe");
            cc_reg_MM.Add("08", "Mandalay");
            cc_reg_MM.Add("09", "Pegu");
            cc_reg_MM.Add("10", "Sagaing");
            cc_reg_MM.Add("11", "Shan State");
            cc_reg_MM.Add("12", "Tenasserim");
            cc_reg_MM.Add("13", "Mon State");
            cc_reg_MM.Add("14", "Rangoon");
            cc_reg_MM.Add("17", "Yangon");
            GEOIP_REGION_NAME.Add("MM", cc_reg_MM);
            Hashtable cc_reg_MN = new Hashtable();
            cc_reg_MN.Add("01", "Arhangay");
            cc_reg_MN.Add("02", "Bayanhongor");
            cc_reg_MN.Add("03", "Bayan-Olgiy");
            cc_reg_MN.Add("05", "Darhan");
            cc_reg_MN.Add("06", "Dornod");
            cc_reg_MN.Add("07", "Dornogovi");
            cc_reg_MN.Add("08", "Dundgovi");
            cc_reg_MN.Add("09", "Dzavhan");
            cc_reg_MN.Add("10", "Govi-Altay");
            cc_reg_MN.Add("11", "Hentiy");
            cc_reg_MN.Add("12", "Hovd");
            cc_reg_MN.Add("13", "Hovsgol");
            cc_reg_MN.Add("14", "Omnogovi");
            cc_reg_MN.Add("15", "Ovorhangay");
            cc_reg_MN.Add("16", "Selenge");
            cc_reg_MN.Add("17", "Suhbaatar");
            cc_reg_MN.Add("18", "Tov");
            cc_reg_MN.Add("19", "Uvs");
            cc_reg_MN.Add("20", "Ulaanbaatar");
            cc_reg_MN.Add("21", "Bulgan");
            cc_reg_MN.Add("22", "Erdenet");
            cc_reg_MN.Add("23", "Darhan-Uul");
            cc_reg_MN.Add("24", "Govisumber");
            cc_reg_MN.Add("25", "Orhon");
            GEOIP_REGION_NAME.Add("MN", cc_reg_MN);
            Hashtable cc_reg_MO = new Hashtable();
            cc_reg_MO.Add("01", "Ilhas");
            cc_reg_MO.Add("02", "Macau");
            GEOIP_REGION_NAME.Add("MO", cc_reg_MO);
            Hashtable cc_reg_MR = new Hashtable();
            cc_reg_MR.Add("01", "Hodh Ech Chargui");
            cc_reg_MR.Add("02", "Hodh El Gharbi");
            cc_reg_MR.Add("03", "Assaba");
            cc_reg_MR.Add("04", "Gorgol");
            cc_reg_MR.Add("05", "Brakna");
            cc_reg_MR.Add("06", "Trarza");
            cc_reg_MR.Add("07", "Adrar");
            cc_reg_MR.Add("08", "Dakhlet Nouadhibou");
            cc_reg_MR.Add("09", "Tagant");
            cc_reg_MR.Add("10", "Guidimaka");
            cc_reg_MR.Add("11", "Tiris Zemmour");
            cc_reg_MR.Add("12", "Inchiri");
            GEOIP_REGION_NAME.Add("MR", cc_reg_MR);
            Hashtable cc_reg_MS = new Hashtable();
            cc_reg_MS.Add("01", "Saint Anthony");
            cc_reg_MS.Add("02", "Saint Georges");
            cc_reg_MS.Add("03", "Saint Peter");
            GEOIP_REGION_NAME.Add("MS", cc_reg_MS);
            Hashtable cc_reg_MU = new Hashtable();
            cc_reg_MU.Add("12", "Black River");
            cc_reg_MU.Add("13", "Flacq");
            cc_reg_MU.Add("14", "Grand Port");
            cc_reg_MU.Add("15", "Moka");
            cc_reg_MU.Add("16", "Pamplemousses");
            cc_reg_MU.Add("17", "Plaines Wilhems");
            cc_reg_MU.Add("18", "Port Louis");
            cc_reg_MU.Add("19", "Riviere du Rempart");
            cc_reg_MU.Add("20", "Savanne");
            cc_reg_MU.Add("21", "Agalega Islands");
            cc_reg_MU.Add("22", "Cargados Carajos");
            cc_reg_MU.Add("23", "Rodrigues");
            GEOIP_REGION_NAME.Add("MU", cc_reg_MU);
            Hashtable cc_reg_MV = new Hashtable();
            cc_reg_MV.Add("01", "Seenu");
            cc_reg_MV.Add("05", "Laamu");
            cc_reg_MV.Add("30", "Alifu");
            cc_reg_MV.Add("31", "Baa");
            cc_reg_MV.Add("32", "Dhaalu");
            cc_reg_MV.Add("33", "Faafu ");
            cc_reg_MV.Add("34", "Gaafu Alifu");
            cc_reg_MV.Add("35", "Gaafu Dhaalu");
            cc_reg_MV.Add("36", "Haa Alifu");
            cc_reg_MV.Add("37", "Haa Dhaalu");
            cc_reg_MV.Add("38", "Kaafu");
            cc_reg_MV.Add("39", "Lhaviyani");
            cc_reg_MV.Add("40", "Maale");
            cc_reg_MV.Add("41", "Meemu");
            cc_reg_MV.Add("42", "Gnaviyani");
            cc_reg_MV.Add("43", "Noonu");
            cc_reg_MV.Add("44", "Raa");
            cc_reg_MV.Add("45", "Shaviyani");
            cc_reg_MV.Add("46", "Thaa");
            cc_reg_MV.Add("47", "Vaavu");
            GEOIP_REGION_NAME.Add("MV", cc_reg_MV);
            Hashtable cc_reg_MW = new Hashtable();
            cc_reg_MW.Add("02", "Chikwawa");
            cc_reg_MW.Add("03", "Chiradzulu");
            cc_reg_MW.Add("04", "Chitipa");
            cc_reg_MW.Add("05", "Thyolo");
            cc_reg_MW.Add("06", "Dedza");
            cc_reg_MW.Add("07", "Dowa");
            cc_reg_MW.Add("08", "Karonga");
            cc_reg_MW.Add("09", "Kasungu");
            cc_reg_MW.Add("11", "Lilongwe");
            cc_reg_MW.Add("12", "Mangochi");
            cc_reg_MW.Add("13", "Mchinji");
            cc_reg_MW.Add("15", "Mzimba");
            cc_reg_MW.Add("16", "Ntcheu");
            cc_reg_MW.Add("17", "Nkhata Bay");
            cc_reg_MW.Add("18", "Nkhotakota");
            cc_reg_MW.Add("19", "Nsanje");
            cc_reg_MW.Add("20", "Ntchisi");
            cc_reg_MW.Add("21", "Rumphi");
            cc_reg_MW.Add("22", "Salima");
            cc_reg_MW.Add("23", "Zomba");
            cc_reg_MW.Add("24", "Blantyre");
            cc_reg_MW.Add("25", "Mwanza");
            cc_reg_MW.Add("26", "Balaka");
            cc_reg_MW.Add("27", "Likoma");
            cc_reg_MW.Add("28", "Machinga");
            cc_reg_MW.Add("29", "Mulanje");
            cc_reg_MW.Add("30", "Phalombe");
            GEOIP_REGION_NAME.Add("MW", cc_reg_MW);
            Hashtable cc_reg_MX = new Hashtable();
            cc_reg_MX.Add("01", "Aguascalientes");
            cc_reg_MX.Add("02", "Baja California");
            cc_reg_MX.Add("03", "Baja California Sur");
            cc_reg_MX.Add("04", "Campeche");
            cc_reg_MX.Add("05", "Chiapas");
            cc_reg_MX.Add("06", "Chihuahua");
            cc_reg_MX.Add("07", "Coahuila de Zaragoza");
            cc_reg_MX.Add("08", "Colima");
            cc_reg_MX.Add("09", "Distrito Federal");
            cc_reg_MX.Add("10", "Durango");
            cc_reg_MX.Add("11", "Guanajuato");
            cc_reg_MX.Add("12", "Guerrero");
            cc_reg_MX.Add("13", "Hidalgo");
            cc_reg_MX.Add("14", "Jalisco");
            cc_reg_MX.Add("15", "Mexico");
            cc_reg_MX.Add("16", "Michoacan de Ocampo");
            cc_reg_MX.Add("17", "Morelos");
            cc_reg_MX.Add("18", "Nayarit");
            cc_reg_MX.Add("19", "Nuevo Leon");
            cc_reg_MX.Add("20", "Oaxaca");
            cc_reg_MX.Add("21", "Puebla");
            cc_reg_MX.Add("22", "Queretaro de Arteaga");
            cc_reg_MX.Add("23", "Quintana Roo");
            cc_reg_MX.Add("24", "San Luis Potosi");
            cc_reg_MX.Add("25", "Sinaloa");
            cc_reg_MX.Add("26", "Sonora");
            cc_reg_MX.Add("27", "Tabasco");
            cc_reg_MX.Add("28", "Tamaulipas");
            cc_reg_MX.Add("29", "Tlaxcala");
            cc_reg_MX.Add("30", "Veracruz-Llave");
            cc_reg_MX.Add("31", "Yucatan");
            cc_reg_MX.Add("32", "Zacatecas");
            GEOIP_REGION_NAME.Add("MX", cc_reg_MX);
            Hashtable cc_reg_MY = new Hashtable();
            cc_reg_MY.Add("01", "Johor");
            cc_reg_MY.Add("02", "Kedah");
            cc_reg_MY.Add("03", "Kelantan");
            cc_reg_MY.Add("04", "Melaka");
            cc_reg_MY.Add("05", "Negeri Sembilan");
            cc_reg_MY.Add("06", "Pahang");
            cc_reg_MY.Add("07", "Perak");
            cc_reg_MY.Add("08", "Perlis");
            cc_reg_MY.Add("09", "Pulau Pinang");
            cc_reg_MY.Add("11", "Sarawak");
            cc_reg_MY.Add("12", "Selangor");
            cc_reg_MY.Add("13", "Terengganu");
            cc_reg_MY.Add("14", "Kuala Lumpur");
            cc_reg_MY.Add("15", "Labuan");
            cc_reg_MY.Add("16", "Sabah");
            cc_reg_MY.Add("17", "Putrajaya");
            GEOIP_REGION_NAME.Add("MY", cc_reg_MY);
            Hashtable cc_reg_MZ = new Hashtable();
            cc_reg_MZ.Add("01", "Cabo Delgado");
            cc_reg_MZ.Add("02", "Gaza");
            cc_reg_MZ.Add("03", "Inhambane");
            cc_reg_MZ.Add("04", "Maputo");
            cc_reg_MZ.Add("05", "Sofala");
            cc_reg_MZ.Add("06", "Nampula");
            cc_reg_MZ.Add("07", "Niassa");
            cc_reg_MZ.Add("08", "Tete");
            cc_reg_MZ.Add("09", "Zambezia");
            cc_reg_MZ.Add("10", "Manica");
            cc_reg_MZ.Add("11", "Maputo");
            GEOIP_REGION_NAME.Add("MZ", cc_reg_MZ);
            Hashtable cc_reg_NA = new Hashtable();
            cc_reg_NA.Add("01", "Bethanien");
            cc_reg_NA.Add("02", "Caprivi Oos");
            cc_reg_NA.Add("03", "Boesmanland");
            cc_reg_NA.Add("04", "Gobabis");
            cc_reg_NA.Add("05", "Grootfontein");
            cc_reg_NA.Add("06", "Kaokoland");
            cc_reg_NA.Add("07", "Karibib");
            cc_reg_NA.Add("08", "Keetmanshoop");
            cc_reg_NA.Add("09", "Luderitz");
            cc_reg_NA.Add("10", "Maltahohe");
            cc_reg_NA.Add("11", "Okahandja");
            cc_reg_NA.Add("12", "Omaruru");
            cc_reg_NA.Add("13", "Otjiwarongo");
            cc_reg_NA.Add("14", "Outjo");
            cc_reg_NA.Add("15", "Owambo");
            cc_reg_NA.Add("16", "Rehoboth");
            cc_reg_NA.Add("17", "Swakopmund");
            cc_reg_NA.Add("18", "Tsumeb");
            cc_reg_NA.Add("20", "Karasburg");
            cc_reg_NA.Add("21", "Windhoek");
            cc_reg_NA.Add("22", "Damaraland");
            cc_reg_NA.Add("23", "Hereroland Oos");
            cc_reg_NA.Add("24", "Hereroland Wes");
            cc_reg_NA.Add("25", "Kavango");
            cc_reg_NA.Add("26", "Mariental");
            cc_reg_NA.Add("27", "Namaland");
            cc_reg_NA.Add("28", "Caprivi");
            cc_reg_NA.Add("29", "Erongo");
            cc_reg_NA.Add("30", "Hardap");
            cc_reg_NA.Add("31", "Karas");
            cc_reg_NA.Add("32", "Kunene");
            cc_reg_NA.Add("33", "Ohangwena");
            cc_reg_NA.Add("34", "Okavango");
            cc_reg_NA.Add("35", "Omaheke");
            cc_reg_NA.Add("36", "Omusati");
            cc_reg_NA.Add("37", "Oshana");
            cc_reg_NA.Add("38", "Oshikoto");
            cc_reg_NA.Add("39", "Otjozondjupa");
            GEOIP_REGION_NAME.Add("NA", cc_reg_NA);
            Hashtable cc_reg_NE = new Hashtable();
            cc_reg_NE.Add("01", "Agadez");
            cc_reg_NE.Add("02", "Diffa");
            cc_reg_NE.Add("03", "Dosso");
            cc_reg_NE.Add("04", "Maradi");
            cc_reg_NE.Add("05", "Niamey");
            cc_reg_NE.Add("06", "Tahoua");
            cc_reg_NE.Add("07", "Zinder");
            cc_reg_NE.Add("08", "Niamey");
            GEOIP_REGION_NAME.Add("NE", cc_reg_NE);
            Hashtable cc_reg_NG = new Hashtable();
            cc_reg_NG.Add("05", "Lagos");
            cc_reg_NG.Add("11", "Federal Capital Territory");
            cc_reg_NG.Add("16", "Ogun");
            cc_reg_NG.Add("21", "Akwa Ibom");
            cc_reg_NG.Add("22", "Cross River");
            cc_reg_NG.Add("23", "Kaduna");
            cc_reg_NG.Add("24", "Katsina");
            cc_reg_NG.Add("25", "Anambra");
            cc_reg_NG.Add("26", "Benue");
            cc_reg_NG.Add("27", "Borno");
            cc_reg_NG.Add("28", "Imo");
            cc_reg_NG.Add("29", "Kano");
            cc_reg_NG.Add("30", "Kwara");
            cc_reg_NG.Add("31", "Niger");
            cc_reg_NG.Add("32", "Oyo");
            cc_reg_NG.Add("35", "Adamawa");
            cc_reg_NG.Add("36", "Delta");
            cc_reg_NG.Add("37", "Edo");
            cc_reg_NG.Add("39", "Jigawa");
            cc_reg_NG.Add("40", "Kebbi");
            cc_reg_NG.Add("41", "Kogi");
            cc_reg_NG.Add("42", "Osun");
            cc_reg_NG.Add("43", "Taraba");
            cc_reg_NG.Add("44", "Yobe");
            cc_reg_NG.Add("45", "Abia");
            cc_reg_NG.Add("46", "Bauchi");
            cc_reg_NG.Add("47", "Enugu");
            cc_reg_NG.Add("48", "Ondo");
            cc_reg_NG.Add("49", "Plateau");
            cc_reg_NG.Add("50", "Rivers");
            cc_reg_NG.Add("51", "Sokoto");
            cc_reg_NG.Add("52", "Bayelsa");
            cc_reg_NG.Add("53", "Ebonyi");
            cc_reg_NG.Add("54", "Ekiti");
            cc_reg_NG.Add("55", "Gombe");
            cc_reg_NG.Add("56", "Nassarawa");
            cc_reg_NG.Add("57", "Zamfara");
            GEOIP_REGION_NAME.Add("NG", cc_reg_NG);
            Hashtable cc_reg_NI = new Hashtable();
            cc_reg_NI.Add("01", "Boaco");
            cc_reg_NI.Add("02", "Carazo");
            cc_reg_NI.Add("03", "Chinandega");
            cc_reg_NI.Add("04", "Chontales");
            cc_reg_NI.Add("05", "Esteli");
            cc_reg_NI.Add("06", "Granada");
            cc_reg_NI.Add("07", "Jinotega");
            cc_reg_NI.Add("08", "Leon");
            cc_reg_NI.Add("09", "Madriz");
            cc_reg_NI.Add("10", "Managua");
            cc_reg_NI.Add("11", "Masaya");
            cc_reg_NI.Add("12", "Matagalpa");
            cc_reg_NI.Add("13", "Nueva Segovia");
            cc_reg_NI.Add("14", "Rio San Juan");
            cc_reg_NI.Add("15", "Rivas");
            cc_reg_NI.Add("16", "Zelaya");
            cc_reg_NI.Add("17", "Autonoma Atlantico Norte");
            cc_reg_NI.Add("18", "Region Autonoma Atlantico Sur");
            GEOIP_REGION_NAME.Add("NI", cc_reg_NI);
            Hashtable cc_reg_NL = new Hashtable();
            cc_reg_NL.Add("01", "Drenthe");
            cc_reg_NL.Add("02", "Friesland");
            cc_reg_NL.Add("03", "Gelderland");
            cc_reg_NL.Add("04", "Groningen");
            cc_reg_NL.Add("05", "Limburg");
            cc_reg_NL.Add("06", "Noord-Brabant");
            cc_reg_NL.Add("07", "Noord-Holland");
            cc_reg_NL.Add("09", "Utrecht");
            cc_reg_NL.Add("10", "Zeeland");
            cc_reg_NL.Add("11", "Zuid-Holland");
            cc_reg_NL.Add("15", "Overijssel");
            cc_reg_NL.Add("16", "Flevoland");
            GEOIP_REGION_NAME.Add("NL", cc_reg_NL);
            Hashtable cc_reg_NO = new Hashtable();
            cc_reg_NO.Add("01", "Akershus");
            cc_reg_NO.Add("02", "Aust-Agder");
            cc_reg_NO.Add("04", "Buskerud");
            cc_reg_NO.Add("05", "Finnmark");
            cc_reg_NO.Add("06", "Hedmark");
            cc_reg_NO.Add("07", "Hordaland");
            cc_reg_NO.Add("08", "More og Romsdal");
            cc_reg_NO.Add("09", "Nordland");
            cc_reg_NO.Add("10", "Nord-Trondelag");
            cc_reg_NO.Add("11", "Oppland");
            cc_reg_NO.Add("12", "Oslo");
            cc_reg_NO.Add("13", "Ostfold");
            cc_reg_NO.Add("14", "Rogaland");
            cc_reg_NO.Add("15", "Sogn og Fjordane");
            cc_reg_NO.Add("16", "Sor-Trondelag");
            cc_reg_NO.Add("17", "Telemark");
            cc_reg_NO.Add("18", "Troms");
            cc_reg_NO.Add("19", "Vest-Agder");
            cc_reg_NO.Add("20", "Vestfold");
            GEOIP_REGION_NAME.Add("NO", cc_reg_NO);
            Hashtable cc_reg_NP = new Hashtable();
            cc_reg_NP.Add("01", "Bagmati");
            cc_reg_NP.Add("02", "Bheri");
            cc_reg_NP.Add("03", "Dhawalagiri");
            cc_reg_NP.Add("04", "Gandaki");
            cc_reg_NP.Add("05", "Janakpur");
            cc_reg_NP.Add("06", "Karnali");
            cc_reg_NP.Add("07", "Kosi");
            cc_reg_NP.Add("08", "Lumbini");
            cc_reg_NP.Add("09", "Mahakali");
            cc_reg_NP.Add("10", "Mechi");
            cc_reg_NP.Add("11", "Narayani");
            cc_reg_NP.Add("12", "Rapti");
            cc_reg_NP.Add("13", "Sagarmatha");
            cc_reg_NP.Add("14", "Seti");
            GEOIP_REGION_NAME.Add("NP", cc_reg_NP);
            Hashtable cc_reg_NR = new Hashtable();
            cc_reg_NR.Add("01", "Aiwo");
            cc_reg_NR.Add("02", "Anabar");
            cc_reg_NR.Add("03", "Anetan");
            cc_reg_NR.Add("04", "Anibare");
            cc_reg_NR.Add("05", "Baiti");
            cc_reg_NR.Add("06", "Boe");
            cc_reg_NR.Add("07", "Buada");
            cc_reg_NR.Add("08", "Denigomodu");
            cc_reg_NR.Add("09", "Ewa");
            cc_reg_NR.Add("10", "Ijuw");
            cc_reg_NR.Add("11", "Meneng");
            cc_reg_NR.Add("12", "Nibok");
            cc_reg_NR.Add("13", "Uaboe");
            cc_reg_NR.Add("14", "Yaren");
            GEOIP_REGION_NAME.Add("NR", cc_reg_NR);
            Hashtable cc_reg_NZ = new Hashtable();
            cc_reg_NZ.Add("10", "Chatham Islands");
            cc_reg_NZ.Add("E7", "Auckland");
            cc_reg_NZ.Add("E8", "Bay of Plenty");
            cc_reg_NZ.Add("E9", "Canterbury");
            cc_reg_NZ.Add("F1", "Gisborne");
            cc_reg_NZ.Add("F2", "Hawke's Bay");
            cc_reg_NZ.Add("F3", "Manawatu-Wanganui");
            cc_reg_NZ.Add("F4", "Marlborough");
            cc_reg_NZ.Add("F5", "Nelson");
            cc_reg_NZ.Add("F6", "Northland");
            cc_reg_NZ.Add("F7", "Otago");
            cc_reg_NZ.Add("F8", "Southland");
            cc_reg_NZ.Add("F9", "Taranaki");
            cc_reg_NZ.Add("G1", "Waikato");
            cc_reg_NZ.Add("G2", "Wellington");
            cc_reg_NZ.Add("G3", "West Coast");
            GEOIP_REGION_NAME.Add("NZ", cc_reg_NZ);
            Hashtable cc_reg_OM = new Hashtable();
            cc_reg_OM.Add("01", "Ad Dakhiliyah");
            cc_reg_OM.Add("02", "Al Batinah");
            cc_reg_OM.Add("03", "Al Wusta");
            cc_reg_OM.Add("04", "Ash Sharqiyah");
            cc_reg_OM.Add("05", "Az Zahirah");
            cc_reg_OM.Add("06", "Masqat");
            cc_reg_OM.Add("07", "Musandam");
            cc_reg_OM.Add("08", "Zufar");
            GEOIP_REGION_NAME.Add("OM", cc_reg_OM);
            Hashtable cc_reg_PA = new Hashtable();
            cc_reg_PA.Add("01", "Bocas del Toro");
            cc_reg_PA.Add("02", "Chiriqui");
            cc_reg_PA.Add("03", "Cocle");
            cc_reg_PA.Add("04", "Colon");
            cc_reg_PA.Add("05", "Darien");
            cc_reg_PA.Add("06", "Herrera");
            cc_reg_PA.Add("07", "Los Santos");
            cc_reg_PA.Add("08", "Panama");
            cc_reg_PA.Add("09", "San Blas");
            cc_reg_PA.Add("10", "Veraguas");
            GEOIP_REGION_NAME.Add("PA", cc_reg_PA);
            Hashtable cc_reg_PE = new Hashtable();
            cc_reg_PE.Add("01", "Amazonas");
            cc_reg_PE.Add("02", "Ancash");
            cc_reg_PE.Add("03", "Apurimac");
            cc_reg_PE.Add("04", "Arequipa");
            cc_reg_PE.Add("05", "Ayacucho");
            cc_reg_PE.Add("06", "Cajamarca");
            cc_reg_PE.Add("07", "Callao");
            cc_reg_PE.Add("08", "Cusco");
            cc_reg_PE.Add("09", "Huancavelica");
            cc_reg_PE.Add("10", "Huanuco");
            cc_reg_PE.Add("11", "Ica");
            cc_reg_PE.Add("12", "Junin");
            cc_reg_PE.Add("13", "La Libertad");
            cc_reg_PE.Add("14", "Lambayeque");
            cc_reg_PE.Add("15", "Lima");
            cc_reg_PE.Add("16", "Loreto");
            cc_reg_PE.Add("17", "Madre de Dios");
            cc_reg_PE.Add("18", "Moquegua");
            cc_reg_PE.Add("19", "Pasco");
            cc_reg_PE.Add("20", "Piura");
            cc_reg_PE.Add("21", "Puno");
            cc_reg_PE.Add("22", "San Martin");
            cc_reg_PE.Add("23", "Tacna");
            cc_reg_PE.Add("24", "Tumbes");
            cc_reg_PE.Add("25", "Ucayali");
            GEOIP_REGION_NAME.Add("PE", cc_reg_PE);
            Hashtable cc_reg_PG = new Hashtable();
            cc_reg_PG.Add("01", "Central");
            cc_reg_PG.Add("02", "Gulf");
            cc_reg_PG.Add("03", "Milne Bay");
            cc_reg_PG.Add("04", "Northern");
            cc_reg_PG.Add("05", "Southern Highlands");
            cc_reg_PG.Add("06", "Western");
            cc_reg_PG.Add("07", "North Solomons");
            cc_reg_PG.Add("08", "Chimbu");
            cc_reg_PG.Add("09", "Eastern Highlands");
            cc_reg_PG.Add("10", "East New Britain");
            cc_reg_PG.Add("11", "East Sepik");
            cc_reg_PG.Add("12", "Madang");
            cc_reg_PG.Add("13", "Manus");
            cc_reg_PG.Add("14", "Morobe");
            cc_reg_PG.Add("15", "New Ireland");
            cc_reg_PG.Add("16", "Western Highlands");
            cc_reg_PG.Add("17", "West New Britain");
            cc_reg_PG.Add("18", "Sandaun");
            cc_reg_PG.Add("19", "Enga");
            cc_reg_PG.Add("20", "National Capital");
            GEOIP_REGION_NAME.Add("PG", cc_reg_PG);
            Hashtable cc_reg_PH = new Hashtable();
            cc_reg_PH.Add("01", "Abra");
            cc_reg_PH.Add("02", "Agusan del Norte");
            cc_reg_PH.Add("03", "Agusan del Sur");
            cc_reg_PH.Add("04", "Aklan");
            cc_reg_PH.Add("05", "Albay");
            cc_reg_PH.Add("06", "Antique");
            cc_reg_PH.Add("07", "Bataan");
            cc_reg_PH.Add("08", "Batanes");
            cc_reg_PH.Add("09", "Batangas");
            cc_reg_PH.Add("10", "Benguet");
            cc_reg_PH.Add("11", "Bohol");
            cc_reg_PH.Add("12", "Bukidnon");
            cc_reg_PH.Add("13", "Bulacan");
            cc_reg_PH.Add("14", "Cagayan");
            cc_reg_PH.Add("15", "Camarines Norte");
            cc_reg_PH.Add("16", "Camarines Sur");
            cc_reg_PH.Add("17", "Camiguin");
            cc_reg_PH.Add("18", "Capiz");
            cc_reg_PH.Add("19", "Catanduanes");
            cc_reg_PH.Add("20", "Cavite");
            cc_reg_PH.Add("21", "Cebu");
            cc_reg_PH.Add("22", "Basilan");
            cc_reg_PH.Add("23", "Eastern Samar");
            cc_reg_PH.Add("24", "Davao");
            cc_reg_PH.Add("25", "Davao del Sur");
            cc_reg_PH.Add("26", "Davao Oriental");
            cc_reg_PH.Add("27", "Ifugao");
            cc_reg_PH.Add("28", "Ilocos Norte");
            cc_reg_PH.Add("29", "Ilocos Sur");
            cc_reg_PH.Add("30", "Iloilo");
            cc_reg_PH.Add("31", "Isabela");
            cc_reg_PH.Add("32", "Kalinga-Apayao");
            cc_reg_PH.Add("33", "Laguna");
            cc_reg_PH.Add("34", "Lanao del Norte");
            cc_reg_PH.Add("35", "Lanao del Sur");
            cc_reg_PH.Add("36", "La Union");
            cc_reg_PH.Add("37", "Leyte");
            cc_reg_PH.Add("38", "Marinduque");
            cc_reg_PH.Add("39", "Masbate");
            cc_reg_PH.Add("40", "Mindoro Occidental");
            cc_reg_PH.Add("41", "Mindoro Oriental");
            cc_reg_PH.Add("42", "Misamis Occidental");
            cc_reg_PH.Add("43", "Misamis Oriental");
            cc_reg_PH.Add("44", "Mountain");
            cc_reg_PH.Add("45", "Negros Occidental");
            cc_reg_PH.Add("46", "Negros Oriental");
            cc_reg_PH.Add("47", "Nueva Ecija");
            cc_reg_PH.Add("48", "Nueva Vizcaya");
            cc_reg_PH.Add("49", "Palawan");
            cc_reg_PH.Add("50", "Pampanga");
            cc_reg_PH.Add("51", "Pangasinan");
            cc_reg_PH.Add("53", "Rizal");
            cc_reg_PH.Add("54", "Romblon");
            cc_reg_PH.Add("55", "Samar");
            cc_reg_PH.Add("56", "Maguindanao");
            cc_reg_PH.Add("57", "North Cotabato");
            cc_reg_PH.Add("58", "Sorsogon");
            cc_reg_PH.Add("59", "Southern Leyte");
            cc_reg_PH.Add("60", "Sulu");
            cc_reg_PH.Add("61", "Surigao del Norte");
            cc_reg_PH.Add("62", "Surigao del Sur");
            cc_reg_PH.Add("63", "Tarlac");
            cc_reg_PH.Add("64", "Zambales");
            cc_reg_PH.Add("65", "Zamboanga del Norte");
            cc_reg_PH.Add("66", "Zamboanga del Sur");
            cc_reg_PH.Add("67", "Northern Samar");
            cc_reg_PH.Add("68", "Quirino");
            cc_reg_PH.Add("69", "Siquijor");
            cc_reg_PH.Add("70", "South Cotabato");
            cc_reg_PH.Add("71", "Sultan Kudarat");
            cc_reg_PH.Add("72", "Tawitawi");
            cc_reg_PH.Add("A1", "Angeles");
            cc_reg_PH.Add("A2", "Bacolod");
            cc_reg_PH.Add("A3", "Bago");
            cc_reg_PH.Add("A4", "Baguio");
            cc_reg_PH.Add("A5", "Bais");
            cc_reg_PH.Add("A6", "Basilan City");
            cc_reg_PH.Add("A7", "Batangas City");
            cc_reg_PH.Add("A8", "Butuan");
            cc_reg_PH.Add("A9", "Cabanatuan");
            cc_reg_PH.Add("B1", "Cadiz");
            cc_reg_PH.Add("B2", "Cagayan de Oro");
            cc_reg_PH.Add("B3", "Calbayog");
            cc_reg_PH.Add("B4", "Caloocan");
            cc_reg_PH.Add("B5", "Canlaon");
            cc_reg_PH.Add("B6", "Cavite City");
            cc_reg_PH.Add("B7", "Cebu City");
            cc_reg_PH.Add("B8", "Cotabato");
            cc_reg_PH.Add("B9", "Dagupan");
            cc_reg_PH.Add("C1", "Danao");
            cc_reg_PH.Add("C2", "Dapitan");
            cc_reg_PH.Add("C3", "Davao City");
            cc_reg_PH.Add("C4", "Dipolog");
            cc_reg_PH.Add("C5", "Dumaguete");
            cc_reg_PH.Add("C6", "General Santos");
            cc_reg_PH.Add("C7", "Gingoog");
            cc_reg_PH.Add("C8", "Iligan");
            cc_reg_PH.Add("C9", "Iloilo City");
            cc_reg_PH.Add("D1", "Iriga");
            cc_reg_PH.Add("D2", "La Carlota");
            cc_reg_PH.Add("D3", "Laoag");
            cc_reg_PH.Add("D4", "Lapu-Lapu");
            cc_reg_PH.Add("D5", "Legaspi");
            cc_reg_PH.Add("D6", "Lipa");
            cc_reg_PH.Add("D7", "Lucena");
            cc_reg_PH.Add("D8", "Mandaue");
            cc_reg_PH.Add("D9", "Manila");
            cc_reg_PH.Add("E1", "Marawi");
            cc_reg_PH.Add("E2", "Naga");
            cc_reg_PH.Add("E3", "Olongapo");
            cc_reg_PH.Add("E4", "Ormoc");
            cc_reg_PH.Add("E5", "Oroquieta");
            cc_reg_PH.Add("E6", "Ozamis");
            cc_reg_PH.Add("E7", "Pagadian");
            cc_reg_PH.Add("E8", "Palayan");
            cc_reg_PH.Add("E9", "Pasay");
            cc_reg_PH.Add("F1", "Puerto Princesa");
            cc_reg_PH.Add("F2", "Quezon City");
            cc_reg_PH.Add("F3", "Roxas");
            cc_reg_PH.Add("F4", "San Carlos");
            cc_reg_PH.Add("F5", "San Carlos");
            cc_reg_PH.Add("F6", "San Jose");
            cc_reg_PH.Add("F7", "San Pablo");
            cc_reg_PH.Add("F8", "Silay");
            cc_reg_PH.Add("F9", "Surigao");
            cc_reg_PH.Add("G1", "Tacloban");
            cc_reg_PH.Add("G2", "Tagaytay");
            cc_reg_PH.Add("G3", "Tagbilaran");
            cc_reg_PH.Add("G4", "Tangub");
            cc_reg_PH.Add("G5", "Toledo");
            cc_reg_PH.Add("G6", "Trece Martires");
            cc_reg_PH.Add("G7", "Zamboanga");
            cc_reg_PH.Add("G8", "Aurora");
            cc_reg_PH.Add("H2", "Quezon");
            cc_reg_PH.Add("H3", "Negros Occidental");
            cc_reg_PH.Add("I6", "Compostela Valley");
            cc_reg_PH.Add("I7", "Davao del Norte");
            cc_reg_PH.Add("J7", "Kalinga");
            cc_reg_PH.Add("K6", "Malaybalay");
            cc_reg_PH.Add("M5", "San Jose del Monte");
            cc_reg_PH.Add("M6", "San Juan");
            cc_reg_PH.Add("M8", "Santiago");
            cc_reg_PH.Add("M9", "Sarangani");
            cc_reg_PH.Add("N1", "Sipalay");
            cc_reg_PH.Add("N3", "Surigao del Norte");
            cc_reg_PH.Add("P1", "Zambales");
            cc_reg_PH.Add("P2", "Zamboanga");
            GEOIP_REGION_NAME.Add("PH", cc_reg_PH);
            Hashtable cc_reg_PK = new Hashtable();
            cc_reg_PK.Add("01", "Federally Administered Tribal Areas");
            cc_reg_PK.Add("02", "Balochistan");
            cc_reg_PK.Add("03", "North-West Frontier");
            cc_reg_PK.Add("04", "Punjab");
            cc_reg_PK.Add("05", "Sindh");
            cc_reg_PK.Add("06", "Azad Kashmir");
            cc_reg_PK.Add("07", "Northern Areas");
            cc_reg_PK.Add("08", "Islamabad");
            GEOIP_REGION_NAME.Add("PK", cc_reg_PK);
            Hashtable cc_reg_PL = new Hashtable();
            cc_reg_PL.Add("72", "Dolnoslaskie");
            cc_reg_PL.Add("73", "Kujawsko-Pomorskie");
            cc_reg_PL.Add("74", "Lodzkie");
            cc_reg_PL.Add("75", "Lubelskie");
            cc_reg_PL.Add("76", "Lubuskie");
            cc_reg_PL.Add("77", "Malopolskie");
            cc_reg_PL.Add("78", "Mazowieckie");
            cc_reg_PL.Add("79", "Opolskie");
            cc_reg_PL.Add("80", "Podkarpackie");
            cc_reg_PL.Add("81", "Podlaskie");
            cc_reg_PL.Add("82", "Pomorskie");
            cc_reg_PL.Add("83", "Slaskie");
            cc_reg_PL.Add("84", "Swietokrzyskie");
            cc_reg_PL.Add("85", "Warminsko-Mazurskie");
            cc_reg_PL.Add("86", "Wielkopolskie");
            cc_reg_PL.Add("87", "Zachodniopomorskie");
            GEOIP_REGION_NAME.Add("PL", cc_reg_PL);
            Hashtable cc_reg_PS = new Hashtable();
            cc_reg_PS.Add("GZ", "Gaza");
            cc_reg_PS.Add("WE", "West Bank");
            GEOIP_REGION_NAME.Add("PS", cc_reg_PS);
            Hashtable cc_reg_PT = new Hashtable();
            cc_reg_PT.Add("02", "Aveiro");
            cc_reg_PT.Add("03", "Beja");
            cc_reg_PT.Add("04", "Braga");
            cc_reg_PT.Add("05", "Braganca");
            cc_reg_PT.Add("06", "Castelo Branco");
            cc_reg_PT.Add("07", "Coimbra");
            cc_reg_PT.Add("08", "Evora");
            cc_reg_PT.Add("09", "Faro");
            cc_reg_PT.Add("10", "Madeira");
            cc_reg_PT.Add("11", "Guarda");
            cc_reg_PT.Add("13", "Leiria");
            cc_reg_PT.Add("14", "Lisboa");
            cc_reg_PT.Add("16", "Portalegre");
            cc_reg_PT.Add("17", "Porto");
            cc_reg_PT.Add("18", "Santarem");
            cc_reg_PT.Add("19", "Setubal");
            cc_reg_PT.Add("20", "Viana do Castelo");
            cc_reg_PT.Add("21", "Vila Real");
            cc_reg_PT.Add("22", "Viseu");
            cc_reg_PT.Add("23", "Azores");
            GEOIP_REGION_NAME.Add("PT", cc_reg_PT);
            Hashtable cc_reg_PY = new Hashtable();
            cc_reg_PY.Add("01", "Alto Parana");
            cc_reg_PY.Add("02", "Amambay");
            cc_reg_PY.Add("03", "Boqueron");
            cc_reg_PY.Add("04", "Caaguazu");
            cc_reg_PY.Add("05", "Caazapa");
            cc_reg_PY.Add("06", "Central");
            cc_reg_PY.Add("07", "Concepcion");
            cc_reg_PY.Add("08", "Cordillera");
            cc_reg_PY.Add("10", "Guaira");
            cc_reg_PY.Add("11", "Itapua");
            cc_reg_PY.Add("12", "Misiones");
            cc_reg_PY.Add("13", "Neembucu");
            cc_reg_PY.Add("15", "Paraguari");
            cc_reg_PY.Add("16", "Presidente Hayes");
            cc_reg_PY.Add("17", "San Pedro");
            cc_reg_PY.Add("19", "Canindeyu");
            cc_reg_PY.Add("20", "Chaco");
            cc_reg_PY.Add("21", "Nueva Asuncion");
            cc_reg_PY.Add("23", "Alto Paraguay");
            GEOIP_REGION_NAME.Add("PY", cc_reg_PY);
            Hashtable cc_reg_QA = new Hashtable();
            cc_reg_QA.Add("01", "Ad Dawhah");
            cc_reg_QA.Add("02", "Al Ghuwariyah");
            cc_reg_QA.Add("03", "Al Jumaliyah");
            cc_reg_QA.Add("04", "Al Khawr");
            cc_reg_QA.Add("05", "Al Wakrah Municipality");
            cc_reg_QA.Add("06", "Ar Rayyan");
            cc_reg_QA.Add("08", "Madinat ach Shamal");
            cc_reg_QA.Add("09", "Umm Salal");
            cc_reg_QA.Add("10", "Al Wakrah");
            cc_reg_QA.Add("11", "Jariyan al Batnah");
            cc_reg_QA.Add("12", "Umm Sa'id");
            GEOIP_REGION_NAME.Add("QA", cc_reg_QA);
            Hashtable cc_reg_RO = new Hashtable();
            cc_reg_RO.Add("01", "Alba");
            cc_reg_RO.Add("02", "Arad");
            cc_reg_RO.Add("03", "Arges");
            cc_reg_RO.Add("04", "Bacau");
            cc_reg_RO.Add("05", "Bihor");
            cc_reg_RO.Add("06", "Bistrita-Nasaud");
            cc_reg_RO.Add("07", "Botosani");
            cc_reg_RO.Add("08", "Braila");
            cc_reg_RO.Add("09", "Brasov");
            cc_reg_RO.Add("10", "Bucuresti");
            cc_reg_RO.Add("11", "Buzau");
            cc_reg_RO.Add("12", "Caras-Severin");
            cc_reg_RO.Add("13", "Cluj");
            cc_reg_RO.Add("14", "Constanta");
            cc_reg_RO.Add("15", "Covasna");
            cc_reg_RO.Add("16", "Dambovita");
            cc_reg_RO.Add("17", "Dolj");
            cc_reg_RO.Add("18", "Galati");
            cc_reg_RO.Add("19", "Gorj");
            cc_reg_RO.Add("20", "Harghita");
            cc_reg_RO.Add("21", "Hunedoara");
            cc_reg_RO.Add("22", "Ialomita");
            cc_reg_RO.Add("23", "Iasi");
            cc_reg_RO.Add("25", "Maramures");
            cc_reg_RO.Add("26", "Mehedinti");
            cc_reg_RO.Add("27", "Mures");
            cc_reg_RO.Add("28", "Neamt");
            cc_reg_RO.Add("29", "Olt");
            cc_reg_RO.Add("30", "Prahova");
            cc_reg_RO.Add("31", "Salaj");
            cc_reg_RO.Add("32", "Satu Mare");
            cc_reg_RO.Add("33", "Sibiu");
            cc_reg_RO.Add("34", "Suceava");
            cc_reg_RO.Add("35", "Teleorman");
            cc_reg_RO.Add("36", "Timis");
            cc_reg_RO.Add("37", "Tulcea");
            cc_reg_RO.Add("38", "Vaslui");
            cc_reg_RO.Add("39", "Valcea");
            cc_reg_RO.Add("40", "Vrancea");
            cc_reg_RO.Add("41", "Calarasi");
            cc_reg_RO.Add("42", "Giurgiu");
            cc_reg_RO.Add("43", "Ilfov");
            GEOIP_REGION_NAME.Add("RO", cc_reg_RO);
            Hashtable cc_reg_RS = new Hashtable();
            cc_reg_RS.Add("01", "Kosovo");
            cc_reg_RS.Add("02", "Vojvodina");
            GEOIP_REGION_NAME.Add("RS", cc_reg_RS);
            Hashtable cc_reg_RU = new Hashtable();
            cc_reg_RU.Add("01", "Adygeya, Republic of");
            cc_reg_RU.Add("02", "Aginsky Buryatsky AO");
            cc_reg_RU.Add("03", "Gorno-Altay");
            cc_reg_RU.Add("04", "Altaisky krai");
            cc_reg_RU.Add("05", "Amur");
            cc_reg_RU.Add("06", "Arkhangel'sk");
            cc_reg_RU.Add("07", "Astrakhan'");
            cc_reg_RU.Add("08", "Bashkortostan");
            cc_reg_RU.Add("09", "Belgorod");
            cc_reg_RU.Add("10", "Bryansk");
            cc_reg_RU.Add("11", "Buryat");
            cc_reg_RU.Add("12", "Chechnya");
            cc_reg_RU.Add("13", "Chelyabinsk");
            cc_reg_RU.Add("14", "Chita");
            cc_reg_RU.Add("15", "Chukot");
            cc_reg_RU.Add("16", "Chuvashia");
            cc_reg_RU.Add("17", "Dagestan");
            cc_reg_RU.Add("18", "Evenk");
            cc_reg_RU.Add("19", "Ingush");
            cc_reg_RU.Add("20", "Irkutsk");
            cc_reg_RU.Add("21", "Ivanovo");
            cc_reg_RU.Add("22", "Kabardin-Balkar");
            cc_reg_RU.Add("23", "Kaliningrad");
            cc_reg_RU.Add("24", "Kalmyk");
            cc_reg_RU.Add("25", "Kaluga");
            cc_reg_RU.Add("26", "Kamchatka");
            cc_reg_RU.Add("27", "Karachay-Cherkess");
            cc_reg_RU.Add("28", "Karelia");
            cc_reg_RU.Add("29", "Kemerovo");
            cc_reg_RU.Add("30", "Khabarovsk");
            cc_reg_RU.Add("31", "Khakass");
            cc_reg_RU.Add("32", "Khanty-Mansiy");
            cc_reg_RU.Add("33", "Kirov");
            cc_reg_RU.Add("34", "Komi");
            cc_reg_RU.Add("35", "Komi-Permyak");
            cc_reg_RU.Add("36", "Koryak");
            cc_reg_RU.Add("37", "Kostroma");
            cc_reg_RU.Add("38", "Krasnodar");
            cc_reg_RU.Add("39", "Krasnoyarsk");
            cc_reg_RU.Add("40", "Kurgan");
            cc_reg_RU.Add("41", "Kursk");
            cc_reg_RU.Add("42", "Leningrad");
            cc_reg_RU.Add("43", "Lipetsk");
            cc_reg_RU.Add("44", "Magadan");
            cc_reg_RU.Add("45", "Mariy-El");
            cc_reg_RU.Add("46", "Mordovia");
            cc_reg_RU.Add("47", "Moskva");
            cc_reg_RU.Add("48", "Moscow City");
            cc_reg_RU.Add("49", "Murmansk");
            cc_reg_RU.Add("50", "Nenets");
            cc_reg_RU.Add("51", "Nizhegorod");
            cc_reg_RU.Add("52", "Novgorod");
            cc_reg_RU.Add("53", "Novosibirsk");
            cc_reg_RU.Add("54", "Omsk");
            cc_reg_RU.Add("55", "Orenburg");
            cc_reg_RU.Add("56", "Orel");
            cc_reg_RU.Add("57", "Penza");
            cc_reg_RU.Add("58", "Perm'");
            cc_reg_RU.Add("59", "Primor'ye");
            cc_reg_RU.Add("60", "Pskov");
            cc_reg_RU.Add("61", "Rostov");
            cc_reg_RU.Add("62", "Ryazan'");
            cc_reg_RU.Add("63", "Sakha");
            cc_reg_RU.Add("64", "Sakhalin");
            cc_reg_RU.Add("65", "Samara");
            cc_reg_RU.Add("66", "Saint Petersburg City");
            cc_reg_RU.Add("67", "Saratov");
            cc_reg_RU.Add("68", "North Ossetia");
            cc_reg_RU.Add("69", "Smolensk");
            cc_reg_RU.Add("70", "Stavropol'");
            cc_reg_RU.Add("71", "Sverdlovsk");
            cc_reg_RU.Add("72", "Tambovskaya oblast");
            cc_reg_RU.Add("73", "Tatarstan");
            cc_reg_RU.Add("74", "Taymyr");
            cc_reg_RU.Add("75", "Tomsk");
            cc_reg_RU.Add("76", "Tula");
            cc_reg_RU.Add("77", "Tver'");
            cc_reg_RU.Add("78", "Tyumen'");
            cc_reg_RU.Add("79", "Tuva");
            cc_reg_RU.Add("80", "Udmurt");
            cc_reg_RU.Add("81", "Ul'yanovsk");
            cc_reg_RU.Add("82", "Ust-Orda Buryat");
            cc_reg_RU.Add("83", "Vladimir");
            cc_reg_RU.Add("84", "Volgograd");
            cc_reg_RU.Add("85", "Vologda");
            cc_reg_RU.Add("86", "Voronezh");
            cc_reg_RU.Add("87", "Yamal-Nenets");
            cc_reg_RU.Add("88", "Yaroslavl'");
            cc_reg_RU.Add("89", "Yevrey");
            cc_reg_RU.Add("90", "Permskiy Kray");
            cc_reg_RU.Add("91", "Krasnoyarskiy Kray");
            cc_reg_RU.Add("92", "Kamchatskiy Kray");
            cc_reg_RU.Add("93", "Zabaykal'skiy Kray");
            GEOIP_REGION_NAME.Add("RU", cc_reg_RU);
            Hashtable cc_reg_RW = new Hashtable();
            cc_reg_RW.Add("01", "Butare");
            cc_reg_RW.Add("06", "Gitarama");
            cc_reg_RW.Add("07", "Kibungo");
            cc_reg_RW.Add("09", "Kigali");
            cc_reg_RW.Add("11", "Est");
            cc_reg_RW.Add("12", "Kigali");
            cc_reg_RW.Add("13", "Nord");
            cc_reg_RW.Add("14", "Ouest");
            cc_reg_RW.Add("15", "Sud");
            GEOIP_REGION_NAME.Add("RW", cc_reg_RW);
            Hashtable cc_reg_SA = new Hashtable();
            cc_reg_SA.Add("02", "Al Bahah");
            cc_reg_SA.Add("05", "Al Madinah");
            cc_reg_SA.Add("06", "Ash Sharqiyah");
            cc_reg_SA.Add("08", "Al Qasim");
            cc_reg_SA.Add("10", "Ar Riyad");
            cc_reg_SA.Add("11", "Asir Province");
            cc_reg_SA.Add("13", "Ha'il");
            cc_reg_SA.Add("14", "Makkah");
            cc_reg_SA.Add("15", "Al Hudud ash Shamaliyah");
            cc_reg_SA.Add("16", "Najran");
            cc_reg_SA.Add("17", "Jizan");
            cc_reg_SA.Add("19", "Tabuk");
            cc_reg_SA.Add("20", "Al Jawf");
            GEOIP_REGION_NAME.Add("SA", cc_reg_SA);
            Hashtable cc_reg_SB = new Hashtable();
            cc_reg_SB.Add("03", "Malaita");
            cc_reg_SB.Add("06", "Guadalcanal");
            cc_reg_SB.Add("07", "Isabel");
            cc_reg_SB.Add("08", "Makira");
            cc_reg_SB.Add("09", "Temotu");
            cc_reg_SB.Add("10", "Central");
            cc_reg_SB.Add("11", "Western");
            cc_reg_SB.Add("12", "Choiseul");
            cc_reg_SB.Add("13", "Rennell and Bellona");
            GEOIP_REGION_NAME.Add("SB", cc_reg_SB);
            Hashtable cc_reg_SC = new Hashtable();
            cc_reg_SC.Add("01", "Anse aux Pins");
            cc_reg_SC.Add("02", "Anse Boileau");
            cc_reg_SC.Add("03", "Anse Etoile");
            cc_reg_SC.Add("04", "Anse Louis");
            cc_reg_SC.Add("05", "Anse Royale");
            cc_reg_SC.Add("06", "Baie Lazare");
            cc_reg_SC.Add("07", "Baie Sainte Anne");
            cc_reg_SC.Add("08", "Beau Vallon");
            cc_reg_SC.Add("09", "Bel Air");
            cc_reg_SC.Add("10", "Bel Ombre");
            cc_reg_SC.Add("11", "Cascade");
            cc_reg_SC.Add("12", "Glacis");
            cc_reg_SC.Add("13", "Grand' Anse");
            cc_reg_SC.Add("14", "Grand' Anse");
            cc_reg_SC.Add("15", "La Digue");
            cc_reg_SC.Add("16", "La Riviere Anglaise");
            cc_reg_SC.Add("17", "Mont Buxton");
            cc_reg_SC.Add("18", "Mont Fleuri");
            cc_reg_SC.Add("19", "Plaisance");
            cc_reg_SC.Add("20", "Pointe La Rue");
            cc_reg_SC.Add("21", "Port Glaud");
            cc_reg_SC.Add("22", "Saint Louis");
            cc_reg_SC.Add("23", "Takamaka");
            GEOIP_REGION_NAME.Add("SC", cc_reg_SC);
            Hashtable cc_reg_SD = new Hashtable();
            cc_reg_SD.Add("27", "Al Wusta");
            cc_reg_SD.Add("28", "Al Istiwa'iyah");
            cc_reg_SD.Add("29", "Al Khartum");
            cc_reg_SD.Add("30", "Ash Shamaliyah");
            cc_reg_SD.Add("31", "Ash Sharqiyah");
            cc_reg_SD.Add("32", "Bahr al Ghazal");
            cc_reg_SD.Add("33", "Darfur");
            cc_reg_SD.Add("34", "Kurdufan");
            cc_reg_SD.Add("35", "Upper Nile");
            cc_reg_SD.Add("40", "Al Wahadah State");
            cc_reg_SD.Add("44", "Central Equatoria State");
            GEOIP_REGION_NAME.Add("SD", cc_reg_SD);
            Hashtable cc_reg_SE = new Hashtable();
            cc_reg_SE.Add("02", "Blekinge Lan");
            cc_reg_SE.Add("03", "Gavleborgs Lan");
            cc_reg_SE.Add("05", "Gotlands Lan");
            cc_reg_SE.Add("06", "Hallands Lan");
            cc_reg_SE.Add("07", "Jamtlands Lan");
            cc_reg_SE.Add("08", "Jonkopings Lan");
            cc_reg_SE.Add("09", "Kalmar Lan");
            cc_reg_SE.Add("10", "Dalarnas Lan");
            cc_reg_SE.Add("12", "Kronobergs Lan");
            cc_reg_SE.Add("14", "Norrbottens Lan");
            cc_reg_SE.Add("15", "Orebro Lan");
            cc_reg_SE.Add("16", "Ostergotlands Lan");
            cc_reg_SE.Add("18", "Sodermanlands Lan");
            cc_reg_SE.Add("21", "Uppsala Lan");
            cc_reg_SE.Add("22", "Varmlands Lan");
            cc_reg_SE.Add("23", "Vasterbottens Lan");
            cc_reg_SE.Add("24", "Vasternorrlands Lan");
            cc_reg_SE.Add("25", "Vastmanlands Lan");
            cc_reg_SE.Add("26", "Stockholms Lan");
            cc_reg_SE.Add("27", "Skane Lan");
            cc_reg_SE.Add("28", "Vastra Gotaland");
            GEOIP_REGION_NAME.Add("SE", cc_reg_SE);
            Hashtable cc_reg_SH = new Hashtable();
            cc_reg_SH.Add("01", "Ascension");
            cc_reg_SH.Add("02", "Saint Helena");
            cc_reg_SH.Add("03", "Tristan da Cunha");
            GEOIP_REGION_NAME.Add("SH", cc_reg_SH);
            Hashtable cc_reg_SI = new Hashtable();
            cc_reg_SI.Add("01", "Ajdovscina Commune");
            cc_reg_SI.Add("02", "Beltinci Commune");
            cc_reg_SI.Add("03", "Bled Commune");
            cc_reg_SI.Add("04", "Bohinj Commune");
            cc_reg_SI.Add("05", "Borovnica Commune");
            cc_reg_SI.Add("06", "Bovec Commune");
            cc_reg_SI.Add("07", "Brda Commune");
            cc_reg_SI.Add("08", "Brezice Commune");
            cc_reg_SI.Add("09", "Brezovica Commune");
            cc_reg_SI.Add("11", "Celje Commune");
            cc_reg_SI.Add("12", "Cerklje na Gorenjskem Commune");
            cc_reg_SI.Add("13", "Cerknica Commune");
            cc_reg_SI.Add("14", "Cerkno Commune");
            cc_reg_SI.Add("15", "Crensovci Commune");
            cc_reg_SI.Add("16", "Crna na Koroskem Commune");
            cc_reg_SI.Add("17", "Crnomelj Commune");
            cc_reg_SI.Add("19", "Divaca Commune");
            cc_reg_SI.Add("20", "Dobrepolje Commune");
            cc_reg_SI.Add("22", "Dol pri Ljubljani Commune");
            cc_reg_SI.Add("24", "Dornava Commune");
            cc_reg_SI.Add("25", "Dravograd Commune");
            cc_reg_SI.Add("26", "Duplek Commune");
            cc_reg_SI.Add("27", "Gorenja vas-Poljane Commune");
            cc_reg_SI.Add("28", "Gorisnica Commune");
            cc_reg_SI.Add("29", "Gornja Radgona Commune");
            cc_reg_SI.Add("30", "Gornji Grad Commune");
            cc_reg_SI.Add("31", "Gornji Petrovci Commune");
            cc_reg_SI.Add("32", "Grosuplje Commune");
            cc_reg_SI.Add("34", "Hrastnik Commune");
            cc_reg_SI.Add("35", "Hrpelje-Kozina Commune");
            cc_reg_SI.Add("36", "Idrija Commune");
            cc_reg_SI.Add("37", "Ig Commune");
            cc_reg_SI.Add("38", "Ilirska Bistrica Commune");
            cc_reg_SI.Add("39", "Ivancna Gorica Commune");
            cc_reg_SI.Add("40", "Izola-Isola Commune");
            cc_reg_SI.Add("42", "Jursinci Commune");
            cc_reg_SI.Add("44", "Kanal Commune");
            cc_reg_SI.Add("45", "Kidricevo Commune");
            cc_reg_SI.Add("46", "Kobarid Commune");
            cc_reg_SI.Add("47", "Kobilje Commune");
            cc_reg_SI.Add("49", "Komen Commune");
            cc_reg_SI.Add("50", "Koper-Capodistria Urban Commune");
            cc_reg_SI.Add("51", "Kozje Commune");
            cc_reg_SI.Add("52", "Kranj Commune");
            cc_reg_SI.Add("53", "Kranjska Gora Commune");
            cc_reg_SI.Add("54", "Krsko Commune");
            cc_reg_SI.Add("55", "Kungota Commune");
            cc_reg_SI.Add("57", "Lasko Commune");
            cc_reg_SI.Add("61", "Ljubljana Urban Commune");
            cc_reg_SI.Add("62", "Ljubno Commune");
            cc_reg_SI.Add("64", "Logatec Commune");
            cc_reg_SI.Add("66", "Loski Potok Commune");
            cc_reg_SI.Add("68", "Lukovica Commune");
            cc_reg_SI.Add("71", "Medvode Commune");
            cc_reg_SI.Add("72", "Menges Commune");
            cc_reg_SI.Add("73", "Metlika Commune");
            cc_reg_SI.Add("74", "Mezica Commune");
            cc_reg_SI.Add("76", "Mislinja Commune");
            cc_reg_SI.Add("77", "Moravce Commune");
            cc_reg_SI.Add("78", "Moravske Toplice Commune");
            cc_reg_SI.Add("79", "Mozirje Commune");
            cc_reg_SI.Add("80", "Murska Sobota Urban Commune");
            cc_reg_SI.Add("81", "Muta Commune");
            cc_reg_SI.Add("82", "Naklo Commune");
            cc_reg_SI.Add("83", "Nazarje Commune");
            cc_reg_SI.Add("84", "Nova Gorica Urban Commune");
            cc_reg_SI.Add("86", "Odranci Commune");
            cc_reg_SI.Add("87", "Ormoz Commune");
            cc_reg_SI.Add("88", "Osilnica Commune");
            cc_reg_SI.Add("89", "Pesnica Commune");
            cc_reg_SI.Add("91", "Pivka Commune");
            cc_reg_SI.Add("92", "Podcetrtek Commune");
            cc_reg_SI.Add("94", "Postojna Commune");
            cc_reg_SI.Add("97", "Puconci Commune");
            cc_reg_SI.Add("98", "Race-Fram Commune");
            cc_reg_SI.Add("99", "Radece Commune");
            cc_reg_SI.Add("A1", "Radenci Commune");
            cc_reg_SI.Add("A2", "Radlje ob Dravi Commune");
            cc_reg_SI.Add("A3", "Radovljica Commune");
            cc_reg_SI.Add("A6", "Rogasovci Commune");
            cc_reg_SI.Add("A7", "Rogaska Slatina Commune");
            cc_reg_SI.Add("A8", "Rogatec Commune");
            cc_reg_SI.Add("B1", "Semic Commune");
            cc_reg_SI.Add("B2", "Sencur Commune");
            cc_reg_SI.Add("B3", "Sentilj Commune");
            cc_reg_SI.Add("B4", "Sentjernej Commune");
            cc_reg_SI.Add("B6", "Sevnica Commune");
            cc_reg_SI.Add("B7", "Sezana Commune");
            cc_reg_SI.Add("B8", "Skocjan Commune");
            cc_reg_SI.Add("B9", "Skofja Loka Commune");
            cc_reg_SI.Add("C1", "Skofljica Commune");
            cc_reg_SI.Add("C2", "Slovenj Gradec Urban Commune");
            cc_reg_SI.Add("C4", "Slovenske Konjice Commune");
            cc_reg_SI.Add("C5", "Smarje pri Jelsah Commune");
            cc_reg_SI.Add("C6", "Smartno ob Paki Commune");
            cc_reg_SI.Add("C7", "Sostanj Commune");
            cc_reg_SI.Add("C8", "Starse Commune");
            cc_reg_SI.Add("C9", "Store Commune");
            cc_reg_SI.Add("D1", "Sveti Jurij Commune");
            cc_reg_SI.Add("D2", "Tolmin Commune");
            cc_reg_SI.Add("D3", "Trbovlje Commune");
            cc_reg_SI.Add("D4", "Trebnje Commune");
            cc_reg_SI.Add("D5", "Trzic Commune");
            cc_reg_SI.Add("D6", "Turnisce Commune");
            cc_reg_SI.Add("D7", "Velenje Urban Commune");
            cc_reg_SI.Add("D8", "Velike Lasce Commune");
            cc_reg_SI.Add("E1", "Vipava Commune");
            cc_reg_SI.Add("E2", "Vitanje Commune");
            cc_reg_SI.Add("E3", "Vodice Commune");
            cc_reg_SI.Add("E5", "Vrhnika Commune");
            cc_reg_SI.Add("E6", "Vuzenica Commune");
            cc_reg_SI.Add("E7", "Zagorje ob Savi Commune");
            cc_reg_SI.Add("E9", "Zavrc Commune");
            cc_reg_SI.Add("F1", "Zelezniki Commune");
            cc_reg_SI.Add("F2", "Ziri Commune");
            cc_reg_SI.Add("F3", "Zrece Commune");
            cc_reg_SI.Add("F4", "Benedikt Commune");
            cc_reg_SI.Add("F5", "Bistrica ob Sotli Commune");
            cc_reg_SI.Add("F6", "Bloke Commune");
            cc_reg_SI.Add("F7", "Braslovce Commune");
            cc_reg_SI.Add("F8", "Cankova Commune");
            cc_reg_SI.Add("F9", "Cerkvenjak Commune");
            cc_reg_SI.Add("G1", "Destrnik Commune");
            cc_reg_SI.Add("G2", "Dobje Commune");
            cc_reg_SI.Add("G3", "Dobrna Commune");
            cc_reg_SI.Add("G4", "Dobrova-Horjul-Polhov Gradec Commune");
            cc_reg_SI.Add("G5", "Dobrovnik-Dobronak Commune");
            cc_reg_SI.Add("G6", "Dolenjske Toplice Commune");
            cc_reg_SI.Add("G7", "Domzale Commune");
            cc_reg_SI.Add("G8", "Grad Commune");
            cc_reg_SI.Add("G9", "Hajdina Commune");
            cc_reg_SI.Add("H1", "Hoce-Slivnica Commune");
            cc_reg_SI.Add("H2", "Hodos-Hodos Commune");
            cc_reg_SI.Add("H3", "Horjul Commune");
            cc_reg_SI.Add("H4", "Jesenice Commune");
            cc_reg_SI.Add("H5", "Jezersko Commune");
            cc_reg_SI.Add("H6", "Kamnik Commune");
            cc_reg_SI.Add("H7", "Kocevje Commune");
            cc_reg_SI.Add("H8", "Komenda Commune");
            cc_reg_SI.Add("H9", "Kostel Commune");
            cc_reg_SI.Add("I1", "Krizevci Commune");
            cc_reg_SI.Add("I2", "Kuzma Commune");
            cc_reg_SI.Add("I3", "Lenart Commune");
            cc_reg_SI.Add("I4", "Lendava-Lendva Commune");
            cc_reg_SI.Add("I5", "Litija Commune");
            cc_reg_SI.Add("I6", "Ljutomer Commune");
            cc_reg_SI.Add("I7", "Loska Dolina Commune");
            cc_reg_SI.Add("I8", "Lovrenc na Pohorju Commune");
            cc_reg_SI.Add("I9", "Luce Commune");
            cc_reg_SI.Add("J1", "Majsperk Commune");
            cc_reg_SI.Add("J2", "Maribor Commune");
            cc_reg_SI.Add("J3", "Markovci Commune");
            cc_reg_SI.Add("J4", "Miklavz na Dravskem polju Commune");
            cc_reg_SI.Add("J5", "Miren-Kostanjevica Commune");
            cc_reg_SI.Add("J6", "Mirna Pec Commune");
            cc_reg_SI.Add("J7", "Novo mesto Urban Commune");
            cc_reg_SI.Add("J8", "Oplotnica Commune");
            cc_reg_SI.Add("J9", "Piran-Pirano Commune");
            cc_reg_SI.Add("K1", "Podlehnik Commune");
            cc_reg_SI.Add("K2", "Podvelka Commune");
            cc_reg_SI.Add("K3", "Polzela Commune");
            cc_reg_SI.Add("K4", "Prebold Commune");
            cc_reg_SI.Add("K5", "Preddvor Commune");
            cc_reg_SI.Add("K6", "Prevalje Commune");
            cc_reg_SI.Add("K7", "Ptuj Urban Commune");
            cc_reg_SI.Add("K8", "Ravne na Koroskem Commune");
            cc_reg_SI.Add("K9", "Razkrizje Commune");
            cc_reg_SI.Add("L1", "Ribnica Commune");
            cc_reg_SI.Add("L2", "Ribnica na Pohorju Commune");
            cc_reg_SI.Add("L3", "Ruse Commune");
            cc_reg_SI.Add("L4", "Salovci Commune");
            cc_reg_SI.Add("L5", "Selnica ob Dravi Commune");
            cc_reg_SI.Add("L6", "Sempeter-Vrtojba Commune");
            cc_reg_SI.Add("L7", "Sentjur pri Celju Commune");
            cc_reg_SI.Add("L8", "Slovenska Bistrica Commune");
            cc_reg_SI.Add("L9", "Smartno pri Litiji Commune");
            cc_reg_SI.Add("M1", "Sodrazica Commune");
            cc_reg_SI.Add("M2", "Solcava Commune");
            cc_reg_SI.Add("M3", "Sveta Ana Commune");
            cc_reg_SI.Add("M4", "Sveti Andraz v Slovenskih goricah Commune");
            cc_reg_SI.Add("M5", "Tabor Commune");
            cc_reg_SI.Add("M6", "Tisina Commune");
            cc_reg_SI.Add("M7", "Trnovska vas Commune");
            cc_reg_SI.Add("M8", "Trzin Commune");
            cc_reg_SI.Add("M9", "Velika Polana Commune");
            cc_reg_SI.Add("N1", "Verzej Commune");
            cc_reg_SI.Add("N2", "Videm Commune");
            cc_reg_SI.Add("N3", "Vojnik Commune");
            cc_reg_SI.Add("N4", "Vransko Commune");
            cc_reg_SI.Add("N5", "Zalec Commune");
            cc_reg_SI.Add("N6", "Zetale Commune");
            cc_reg_SI.Add("N7", "Zirovnica Commune");
            cc_reg_SI.Add("N8", "Zuzemberk Commune");
            cc_reg_SI.Add("N9", "Apace Commune");
            cc_reg_SI.Add("O1", "Cirkulane Commune");
            GEOIP_REGION_NAME.Add("SI", cc_reg_SI);
            Hashtable cc_reg_SK = new Hashtable();
            cc_reg_SK.Add("01", "Banska Bystrica");
            cc_reg_SK.Add("02", "Bratislava");
            cc_reg_SK.Add("03", "Kosice");
            cc_reg_SK.Add("04", "Nitra");
            cc_reg_SK.Add("05", "Presov");
            cc_reg_SK.Add("06", "Trencin");
            cc_reg_SK.Add("07", "Trnava");
            cc_reg_SK.Add("08", "Zilina");
            GEOIP_REGION_NAME.Add("SK", cc_reg_SK);
            Hashtable cc_reg_SL = new Hashtable();
            cc_reg_SL.Add("01", "Eastern");
            cc_reg_SL.Add("02", "Northern");
            cc_reg_SL.Add("03", "Southern");
            cc_reg_SL.Add("04", "Western Area");
            GEOIP_REGION_NAME.Add("SL", cc_reg_SL);
            Hashtable cc_reg_SM = new Hashtable();
            cc_reg_SM.Add("01", "Acquaviva");
            cc_reg_SM.Add("02", "Chiesanuova");
            cc_reg_SM.Add("03", "Domagnano");
            cc_reg_SM.Add("04", "Faetano");
            cc_reg_SM.Add("05", "Fiorentino");
            cc_reg_SM.Add("06", "Borgo Maggiore");
            cc_reg_SM.Add("07", "San Marino");
            cc_reg_SM.Add("08", "Monte Giardino");
            cc_reg_SM.Add("09", "Serravalle");
            GEOIP_REGION_NAME.Add("SM", cc_reg_SM);
            Hashtable cc_reg_SN = new Hashtable();
            cc_reg_SN.Add("01", "Dakar");
            cc_reg_SN.Add("03", "Diourbel");
            cc_reg_SN.Add("05", "Tambacounda");
            cc_reg_SN.Add("07", "Thies");
            cc_reg_SN.Add("09", "Fatick");
            cc_reg_SN.Add("10", "Kaolack");
            cc_reg_SN.Add("11", "Kolda");
            cc_reg_SN.Add("12", "Ziguinchor");
            cc_reg_SN.Add("13", "Louga");
            cc_reg_SN.Add("14", "Saint-Louis");
            cc_reg_SN.Add("15", "Matam");
            GEOIP_REGION_NAME.Add("SN", cc_reg_SN);
            Hashtable cc_reg_SO = new Hashtable();
            cc_reg_SO.Add("01", "Bakool");
            cc_reg_SO.Add("02", "Banaadir");
            cc_reg_SO.Add("03", "Bari");
            cc_reg_SO.Add("04", "Bay");
            cc_reg_SO.Add("05", "Galguduud");
            cc_reg_SO.Add("06", "Gedo");
            cc_reg_SO.Add("07", "Hiiraan");
            cc_reg_SO.Add("08", "Jubbada Dhexe");
            cc_reg_SO.Add("09", "Jubbada Hoose");
            cc_reg_SO.Add("10", "Mudug");
            cc_reg_SO.Add("11", "Nugaal");
            cc_reg_SO.Add("12", "Sanaag");
            cc_reg_SO.Add("13", "Shabeellaha Dhexe");
            cc_reg_SO.Add("14", "Shabeellaha Hoose");
            cc_reg_SO.Add("16", "Woqooyi Galbeed");
            cc_reg_SO.Add("18", "Nugaal");
            cc_reg_SO.Add("19", "Togdheer");
            cc_reg_SO.Add("20", "Woqooyi Galbeed");
            cc_reg_SO.Add("21", "Awdal");
            cc_reg_SO.Add("22", "Sool");
            GEOIP_REGION_NAME.Add("SO", cc_reg_SO);
            Hashtable cc_reg_SR = new Hashtable();
            cc_reg_SR.Add("10", "Brokopondo");
            cc_reg_SR.Add("11", "Commewijne");
            cc_reg_SR.Add("12", "Coronie");
            cc_reg_SR.Add("13", "Marowijne");
            cc_reg_SR.Add("14", "Nickerie");
            cc_reg_SR.Add("15", "Para");
            cc_reg_SR.Add("16", "Paramaribo");
            cc_reg_SR.Add("17", "Saramacca");
            cc_reg_SR.Add("18", "Sipaliwini");
            cc_reg_SR.Add("19", "Wanica");
            GEOIP_REGION_NAME.Add("SR", cc_reg_SR);
            Hashtable cc_reg_SS = new Hashtable();
            cc_reg_SS.Add("01", "Central Equatoria");
            cc_reg_SS.Add("02", "Eastern Equatoria");
            cc_reg_SS.Add("03", "Jonglei");
            cc_reg_SS.Add("04", "Lakes");
            cc_reg_SS.Add("05", "Northern Bahr el Ghazal");
            cc_reg_SS.Add("06", "Unity");
            cc_reg_SS.Add("07", "Upper Nile");
            cc_reg_SS.Add("08", "Warrap");
            cc_reg_SS.Add("09", "Western Bahr el Ghazal");
            cc_reg_SS.Add("10", "Western Equatoria");
            GEOIP_REGION_NAME.Add("SS", cc_reg_SS);
            Hashtable cc_reg_ST = new Hashtable();
            cc_reg_ST.Add("01", "Principe");
            cc_reg_ST.Add("02", "Sao Tome");
            GEOIP_REGION_NAME.Add("ST", cc_reg_ST);
            Hashtable cc_reg_SV = new Hashtable();
            cc_reg_SV.Add("01", "Ahuachapan");
            cc_reg_SV.Add("02", "Cabanas");
            cc_reg_SV.Add("03", "Chalatenango");
            cc_reg_SV.Add("04", "Cuscatlan");
            cc_reg_SV.Add("05", "La Libertad");
            cc_reg_SV.Add("06", "La Paz");
            cc_reg_SV.Add("07", "La Union");
            cc_reg_SV.Add("08", "Morazan");
            cc_reg_SV.Add("09", "San Miguel");
            cc_reg_SV.Add("10", "San Salvador");
            cc_reg_SV.Add("11", "Santa Ana");
            cc_reg_SV.Add("12", "San Vicente");
            cc_reg_SV.Add("13", "Sonsonate");
            cc_reg_SV.Add("14", "Usulutan");
            GEOIP_REGION_NAME.Add("SV", cc_reg_SV);
            Hashtable cc_reg_SY = new Hashtable();
            cc_reg_SY.Add("01", "Al Hasakah");
            cc_reg_SY.Add("02", "Al Ladhiqiyah");
            cc_reg_SY.Add("03", "Al Qunaytirah");
            cc_reg_SY.Add("04", "Ar Raqqah");
            cc_reg_SY.Add("05", "As Suwayda'");
            cc_reg_SY.Add("06", "Dar");
            cc_reg_SY.Add("07", "Dayr az Zawr");
            cc_reg_SY.Add("08", "Rif Dimashq");
            cc_reg_SY.Add("09", "Halab");
            cc_reg_SY.Add("10", "Hamah");
            cc_reg_SY.Add("11", "Hims");
            cc_reg_SY.Add("12", "Idlib");
            cc_reg_SY.Add("13", "Dimashq");
            cc_reg_SY.Add("14", "Tartus");
            GEOIP_REGION_NAME.Add("SY", cc_reg_SY);
            Hashtable cc_reg_SZ = new Hashtable();
            cc_reg_SZ.Add("01", "Hhohho");
            cc_reg_SZ.Add("02", "Lubombo");
            cc_reg_SZ.Add("03", "Manzini");
            cc_reg_SZ.Add("04", "Shiselweni");
            cc_reg_SZ.Add("05", "Praslin");
            GEOIP_REGION_NAME.Add("SZ", cc_reg_SZ);
            Hashtable cc_reg_TD = new Hashtable();
            cc_reg_TD.Add("01", "Batha");
            cc_reg_TD.Add("02", "Biltine");
            cc_reg_TD.Add("03", "Borkou-Ennedi-Tibesti");
            cc_reg_TD.Add("04", "Chari-Baguirmi");
            cc_reg_TD.Add("05", "Guera");
            cc_reg_TD.Add("06", "Kanem");
            cc_reg_TD.Add("07", "Lac");
            cc_reg_TD.Add("08", "Logone Occidental");
            cc_reg_TD.Add("09", "Logone Oriental");
            cc_reg_TD.Add("10", "Mayo-Kebbi");
            cc_reg_TD.Add("11", "Moyen-Chari");
            cc_reg_TD.Add("12", "Ouaddai");
            cc_reg_TD.Add("13", "Salamat");
            cc_reg_TD.Add("14", "Tandjile");
            GEOIP_REGION_NAME.Add("TD", cc_reg_TD);
            Hashtable cc_reg_TG = new Hashtable();
            cc_reg_TG.Add("22", "Centrale");
            cc_reg_TG.Add("23", "Kara");
            cc_reg_TG.Add("24", "Maritime");
            cc_reg_TG.Add("25", "Plateaux");
            cc_reg_TG.Add("26", "Savanes");
            GEOIP_REGION_NAME.Add("TG", cc_reg_TG);
            Hashtable cc_reg_TH = new Hashtable();
            cc_reg_TH.Add("01", "Mae Hong Son");
            cc_reg_TH.Add("02", "Chiang Mai");
            cc_reg_TH.Add("03", "Chiang Rai");
            cc_reg_TH.Add("04", "Nan");
            cc_reg_TH.Add("05", "Lamphun");
            cc_reg_TH.Add("06", "Lampang");
            cc_reg_TH.Add("07", "Phrae");
            cc_reg_TH.Add("08", "Tak");
            cc_reg_TH.Add("09", "Sukhothai");
            cc_reg_TH.Add("10", "Uttaradit");
            cc_reg_TH.Add("11", "Kamphaeng Phet");
            cc_reg_TH.Add("12", "Phitsanulok");
            cc_reg_TH.Add("13", "Phichit");
            cc_reg_TH.Add("14", "Phetchabun");
            cc_reg_TH.Add("15", "Uthai Thani");
            cc_reg_TH.Add("16", "Nakhon Sawan");
            cc_reg_TH.Add("17", "Nong Khai");
            cc_reg_TH.Add("18", "Loei");
            cc_reg_TH.Add("20", "Sakon Nakhon");
            cc_reg_TH.Add("21", "Nakhon Phanom");
            cc_reg_TH.Add("22", "Khon Kaen");
            cc_reg_TH.Add("23", "Kalasin");
            cc_reg_TH.Add("24", "Maha Sarakham");
            cc_reg_TH.Add("25", "Roi Et");
            cc_reg_TH.Add("26", "Chaiyaphum");
            cc_reg_TH.Add("27", "Nakhon Ratchasima");
            cc_reg_TH.Add("28", "Buriram");
            cc_reg_TH.Add("29", "Surin");
            cc_reg_TH.Add("30", "Sisaket");
            cc_reg_TH.Add("31", "Narathiwat");
            cc_reg_TH.Add("32", "Chai Nat");
            cc_reg_TH.Add("33", "Sing Buri");
            cc_reg_TH.Add("34", "Lop Buri");
            cc_reg_TH.Add("35", "Ang Thong");
            cc_reg_TH.Add("36", "Phra Nakhon Si Ayutthaya");
            cc_reg_TH.Add("37", "Saraburi");
            cc_reg_TH.Add("38", "Nonthaburi");
            cc_reg_TH.Add("39", "Pathum Thani");
            cc_reg_TH.Add("40", "Krung Thep");
            cc_reg_TH.Add("41", "Phayao");
            cc_reg_TH.Add("42", "Samut Prakan");
            cc_reg_TH.Add("43", "Nakhon Nayok");
            cc_reg_TH.Add("44", "Chachoengsao");
            cc_reg_TH.Add("45", "Prachin Buri");
            cc_reg_TH.Add("46", "Chon Buri");
            cc_reg_TH.Add("47", "Rayong");
            cc_reg_TH.Add("48", "Chanthaburi");
            cc_reg_TH.Add("49", "Trat");
            cc_reg_TH.Add("50", "Kanchanaburi");
            cc_reg_TH.Add("51", "Suphan Buri");
            cc_reg_TH.Add("52", "Ratchaburi");
            cc_reg_TH.Add("53", "Nakhon Pathom");
            cc_reg_TH.Add("54", "Samut Songkhram");
            cc_reg_TH.Add("55", "Samut Sakhon");
            cc_reg_TH.Add("56", "Phetchaburi");
            cc_reg_TH.Add("57", "Prachuap Khiri Khan");
            cc_reg_TH.Add("58", "Chumphon");
            cc_reg_TH.Add("59", "Ranong");
            cc_reg_TH.Add("60", "Surat Thani");
            cc_reg_TH.Add("61", "Phangnga");
            cc_reg_TH.Add("62", "Phuket");
            cc_reg_TH.Add("63", "Krabi");
            cc_reg_TH.Add("64", "Nakhon Si Thammarat");
            cc_reg_TH.Add("65", "Trang");
            cc_reg_TH.Add("66", "Phatthalung");
            cc_reg_TH.Add("67", "Satun");
            cc_reg_TH.Add("68", "Songkhla");
            cc_reg_TH.Add("69", "Pattani");
            cc_reg_TH.Add("70", "Yala");
            cc_reg_TH.Add("71", "Ubon Ratchathani");
            cc_reg_TH.Add("72", "Yasothon");
            cc_reg_TH.Add("73", "Nakhon Phanom");
            cc_reg_TH.Add("74", "Prachin Buri");
            cc_reg_TH.Add("75", "Ubon Ratchathani");
            cc_reg_TH.Add("76", "Udon Thani");
            cc_reg_TH.Add("77", "Amnat Charoen");
            cc_reg_TH.Add("78", "Mukdahan");
            cc_reg_TH.Add("79", "Nong Bua Lamphu");
            cc_reg_TH.Add("80", "Sa Kaeo");
            GEOIP_REGION_NAME.Add("TH", cc_reg_TH);
            Hashtable cc_reg_TJ = new Hashtable();
            cc_reg_TJ.Add("01", "Kuhistoni Badakhshon");
            cc_reg_TJ.Add("02", "Khatlon");
            cc_reg_TJ.Add("03", "Sughd");
            GEOIP_REGION_NAME.Add("TJ", cc_reg_TJ);
            Hashtable cc_reg_TM = new Hashtable();
            cc_reg_TM.Add("01", "Ahal");
            cc_reg_TM.Add("02", "Balkan");
            cc_reg_TM.Add("03", "Dashoguz");
            cc_reg_TM.Add("04", "Lebap");
            cc_reg_TM.Add("05", "Mary");
            GEOIP_REGION_NAME.Add("TM", cc_reg_TM);
            Hashtable cc_reg_TN = new Hashtable();
            cc_reg_TN.Add("02", "Kasserine");
            cc_reg_TN.Add("03", "Kairouan");
            cc_reg_TN.Add("06", "Jendouba");
            cc_reg_TN.Add("10", "Qafsah");
            cc_reg_TN.Add("14", "El Kef");
            cc_reg_TN.Add("15", "Al Mahdia");
            cc_reg_TN.Add("16", "Al Munastir");
            cc_reg_TN.Add("17", "Bajah");
            cc_reg_TN.Add("18", "Bizerte");
            cc_reg_TN.Add("19", "Nabeul");
            cc_reg_TN.Add("22", "Siliana");
            cc_reg_TN.Add("23", "Sousse");
            cc_reg_TN.Add("27", "Ben Arous");
            cc_reg_TN.Add("28", "Madanin");
            cc_reg_TN.Add("29", "Gabes");
            cc_reg_TN.Add("31", "Kebili");
            cc_reg_TN.Add("32", "Sfax");
            cc_reg_TN.Add("33", "Sidi Bou Zid");
            cc_reg_TN.Add("34", "Tataouine");
            cc_reg_TN.Add("35", "Tozeur");
            cc_reg_TN.Add("36", "Tunis");
            cc_reg_TN.Add("37", "Zaghouan");
            cc_reg_TN.Add("38", "Aiana");
            cc_reg_TN.Add("39", "Manouba");
            GEOIP_REGION_NAME.Add("TN", cc_reg_TN);
            Hashtable cc_reg_TO = new Hashtable();
            cc_reg_TO.Add("01", "Ha");
            cc_reg_TO.Add("02", "Tongatapu");
            cc_reg_TO.Add("03", "Vava");
            GEOIP_REGION_NAME.Add("TO", cc_reg_TO);
            Hashtable cc_reg_TR = new Hashtable();
            cc_reg_TR.Add("02", "Adiyaman");
            cc_reg_TR.Add("03", "Afyonkarahisar");
            cc_reg_TR.Add("04", "Agri");
            cc_reg_TR.Add("05", "Amasya");
            cc_reg_TR.Add("07", "Antalya");
            cc_reg_TR.Add("08", "Artvin");
            cc_reg_TR.Add("09", "Aydin");
            cc_reg_TR.Add("10", "Balikesir");
            cc_reg_TR.Add("11", "Bilecik");
            cc_reg_TR.Add("12", "Bingol");
            cc_reg_TR.Add("13", "Bitlis");
            cc_reg_TR.Add("14", "Bolu");
            cc_reg_TR.Add("15", "Burdur");
            cc_reg_TR.Add("16", "Bursa");
            cc_reg_TR.Add("17", "Canakkale");
            cc_reg_TR.Add("19", "Corum");
            cc_reg_TR.Add("20", "Denizli");
            cc_reg_TR.Add("21", "Diyarbakir");
            cc_reg_TR.Add("22", "Edirne");
            cc_reg_TR.Add("23", "Elazig");
            cc_reg_TR.Add("24", "Erzincan");
            cc_reg_TR.Add("25", "Erzurum");
            cc_reg_TR.Add("26", "Eskisehir");
            cc_reg_TR.Add("28", "Giresun");
            cc_reg_TR.Add("31", "Hatay");
            cc_reg_TR.Add("32", "Mersin");
            cc_reg_TR.Add("33", "Isparta");
            cc_reg_TR.Add("34", "Istanbul");
            cc_reg_TR.Add("35", "Izmir");
            cc_reg_TR.Add("37", "Kastamonu");
            cc_reg_TR.Add("38", "Kayseri");
            cc_reg_TR.Add("39", "Kirklareli");
            cc_reg_TR.Add("40", "Kirsehir");
            cc_reg_TR.Add("41", "Kocaeli");
            cc_reg_TR.Add("43", "Kutahya");
            cc_reg_TR.Add("44", "Malatya");
            cc_reg_TR.Add("45", "Manisa");
            cc_reg_TR.Add("46", "Kahramanmaras");
            cc_reg_TR.Add("48", "Mugla");
            cc_reg_TR.Add("49", "Mus");
            cc_reg_TR.Add("50", "Nevsehir");
            cc_reg_TR.Add("52", "Ordu");
            cc_reg_TR.Add("53", "Rize");
            cc_reg_TR.Add("54", "Sakarya");
            cc_reg_TR.Add("55", "Samsun");
            cc_reg_TR.Add("57", "Sinop");
            cc_reg_TR.Add("58", "Sivas");
            cc_reg_TR.Add("59", "Tekirdag");
            cc_reg_TR.Add("60", "Tokat");
            cc_reg_TR.Add("61", "Trabzon");
            cc_reg_TR.Add("62", "Tunceli");
            cc_reg_TR.Add("63", "Sanliurfa");
            cc_reg_TR.Add("64", "Usak");
            cc_reg_TR.Add("65", "Van");
            cc_reg_TR.Add("66", "Yozgat");
            cc_reg_TR.Add("68", "Ankara");
            cc_reg_TR.Add("69", "Gumushane");
            cc_reg_TR.Add("70", "Hakkari");
            cc_reg_TR.Add("71", "Konya");
            cc_reg_TR.Add("72", "Mardin");
            cc_reg_TR.Add("73", "Nigde");
            cc_reg_TR.Add("74", "Siirt");
            cc_reg_TR.Add("75", "Aksaray");
            cc_reg_TR.Add("76", "Batman");
            cc_reg_TR.Add("77", "Bayburt");
            cc_reg_TR.Add("78", "Karaman");
            cc_reg_TR.Add("79", "Kirikkale");
            cc_reg_TR.Add("80", "Sirnak");
            cc_reg_TR.Add("81", "Adana");
            cc_reg_TR.Add("82", "Cankiri");
            cc_reg_TR.Add("83", "Gaziantep");
            cc_reg_TR.Add("84", "Kars");
            cc_reg_TR.Add("85", "Zonguldak");
            cc_reg_TR.Add("86", "Ardahan");
            cc_reg_TR.Add("87", "Bartin");
            cc_reg_TR.Add("88", "Igdir");
            cc_reg_TR.Add("89", "Karabuk");
            cc_reg_TR.Add("90", "Kilis");
            cc_reg_TR.Add("91", "Osmaniye");
            cc_reg_TR.Add("92", "Yalova");
            cc_reg_TR.Add("93", "Duzce");
            GEOIP_REGION_NAME.Add("TR", cc_reg_TR);
            Hashtable cc_reg_TT = new Hashtable();
            cc_reg_TT.Add("01", "Arima");
            cc_reg_TT.Add("02", "Caroni");
            cc_reg_TT.Add("03", "Mayaro");
            cc_reg_TT.Add("04", "Nariva");
            cc_reg_TT.Add("05", "Port-of-Spain");
            cc_reg_TT.Add("06", "Saint Andrew");
            cc_reg_TT.Add("07", "Saint David");
            cc_reg_TT.Add("08", "Saint George");
            cc_reg_TT.Add("09", "Saint Patrick");
            cc_reg_TT.Add("10", "San Fernando");
            cc_reg_TT.Add("11", "Tobago");
            cc_reg_TT.Add("12", "Victoria");
            GEOIP_REGION_NAME.Add("TT", cc_reg_TT);
            Hashtable cc_reg_TW = new Hashtable();
            cc_reg_TW.Add("01", "Fu-chien");
            cc_reg_TW.Add("02", "Kao-hsiung");
            cc_reg_TW.Add("03", "T'ai-pei");
            cc_reg_TW.Add("04", "T'ai-wan");
            GEOIP_REGION_NAME.Add("TW", cc_reg_TW);
            Hashtable cc_reg_TZ = new Hashtable();
            cc_reg_TZ.Add("02", "Pwani");
            cc_reg_TZ.Add("03", "Dodoma");
            cc_reg_TZ.Add("04", "Iringa");
            cc_reg_TZ.Add("05", "Kigoma");
            cc_reg_TZ.Add("06", "Kilimanjaro");
            cc_reg_TZ.Add("07", "Lindi");
            cc_reg_TZ.Add("08", "Mara");
            cc_reg_TZ.Add("09", "Mbeya");
            cc_reg_TZ.Add("10", "Morogoro");
            cc_reg_TZ.Add("11", "Mtwara");
            cc_reg_TZ.Add("12", "Mwanza");
            cc_reg_TZ.Add("13", "Pemba North");
            cc_reg_TZ.Add("14", "Ruvuma");
            cc_reg_TZ.Add("15", "Shinyanga");
            cc_reg_TZ.Add("16", "Singida");
            cc_reg_TZ.Add("17", "Tabora");
            cc_reg_TZ.Add("18", "Tanga");
            cc_reg_TZ.Add("19", "Kagera");
            cc_reg_TZ.Add("20", "Pemba South");
            cc_reg_TZ.Add("21", "Zanzibar Central");
            cc_reg_TZ.Add("22", "Zanzibar North");
            cc_reg_TZ.Add("23", "Dar es Salaam");
            cc_reg_TZ.Add("24", "Rukwa");
            cc_reg_TZ.Add("25", "Zanzibar Urban");
            cc_reg_TZ.Add("26", "Arusha");
            cc_reg_TZ.Add("27", "Manyara");
            GEOIP_REGION_NAME.Add("TZ", cc_reg_TZ);
            Hashtable cc_reg_UA = new Hashtable();
            cc_reg_UA.Add("01", "Cherkas'ka Oblast'");
            cc_reg_UA.Add("02", "Chernihivs'ka Oblast'");
            cc_reg_UA.Add("03", "Chernivets'ka Oblast'");
            cc_reg_UA.Add("04", "Dnipropetrovs'ka Oblast'");
            cc_reg_UA.Add("05", "Donets'ka Oblast'");
            cc_reg_UA.Add("06", "Ivano-Frankivs'ka Oblast'");
            cc_reg_UA.Add("07", "Kharkivs'ka Oblast'");
            cc_reg_UA.Add("08", "Khersons'ka Oblast'");
            cc_reg_UA.Add("09", "Khmel'nyts'ka Oblast'");
            cc_reg_UA.Add("10", "Kirovohrads'ka Oblast'");
            cc_reg_UA.Add("11", "Krym");
            cc_reg_UA.Add("12", "Kyyiv");
            cc_reg_UA.Add("13", "Kyyivs'ka Oblast'");
            cc_reg_UA.Add("14", "Luhans'ka Oblast'");
            cc_reg_UA.Add("15", "L'vivs'ka Oblast'");
            cc_reg_UA.Add("16", "Mykolayivs'ka Oblast'");
            cc_reg_UA.Add("17", "Odes'ka Oblast'");
            cc_reg_UA.Add("18", "Poltavs'ka Oblast'");
            cc_reg_UA.Add("19", "Rivnens'ka Oblast'");
            cc_reg_UA.Add("20", "Sevastopol'");
            cc_reg_UA.Add("21", "Sums'ka Oblast'");
            cc_reg_UA.Add("22", "Ternopil's'ka Oblast'");
            cc_reg_UA.Add("23", "Vinnyts'ka Oblast'");
            cc_reg_UA.Add("24", "Volyns'ka Oblast'");
            cc_reg_UA.Add("25", "Zakarpats'ka Oblast'");
            cc_reg_UA.Add("26", "Zaporiz'ka Oblast'");
            cc_reg_UA.Add("27", "Zhytomyrs'ka Oblast'");
            GEOIP_REGION_NAME.Add("UA", cc_reg_UA);
            Hashtable cc_reg_UG = new Hashtable();
            cc_reg_UG.Add("26", "Apac");
            cc_reg_UG.Add("28", "Bundibugyo");
            cc_reg_UG.Add("29", "Bushenyi");
            cc_reg_UG.Add("30", "Gulu");
            cc_reg_UG.Add("31", "Hoima");
            cc_reg_UG.Add("33", "Jinja");
            cc_reg_UG.Add("36", "Kalangala");
            cc_reg_UG.Add("37", "Kampala");
            cc_reg_UG.Add("38", "Kamuli");
            cc_reg_UG.Add("39", "Kapchorwa");
            cc_reg_UG.Add("40", "Kasese");
            cc_reg_UG.Add("41", "Kibale");
            cc_reg_UG.Add("42", "Kiboga");
            cc_reg_UG.Add("43", "Kisoro");
            cc_reg_UG.Add("45", "Kotido");
            cc_reg_UG.Add("46", "Kumi");
            cc_reg_UG.Add("47", "Lira");
            cc_reg_UG.Add("50", "Masindi");
            cc_reg_UG.Add("52", "Mbarara");
            cc_reg_UG.Add("56", "Mubende");
            cc_reg_UG.Add("58", "Nebbi");
            cc_reg_UG.Add("59", "Ntungamo");
            cc_reg_UG.Add("60", "Pallisa");
            cc_reg_UG.Add("61", "Rakai");
            cc_reg_UG.Add("65", "Adjumani");
            cc_reg_UG.Add("66", "Bugiri");
            cc_reg_UG.Add("67", "Busia");
            cc_reg_UG.Add("69", "Katakwi");
            cc_reg_UG.Add("70", "Luwero");
            cc_reg_UG.Add("71", "Masaka");
            cc_reg_UG.Add("72", "Moyo");
            cc_reg_UG.Add("73", "Nakasongola");
            cc_reg_UG.Add("74", "Sembabule");
            cc_reg_UG.Add("76", "Tororo");
            cc_reg_UG.Add("77", "Arua");
            cc_reg_UG.Add("78", "Iganga");
            cc_reg_UG.Add("79", "Kabarole");
            cc_reg_UG.Add("80", "Kaberamaido");
            cc_reg_UG.Add("81", "Kamwenge");
            cc_reg_UG.Add("82", "Kanungu");
            cc_reg_UG.Add("83", "Kayunga");
            cc_reg_UG.Add("84", "Kitgum");
            cc_reg_UG.Add("85", "Kyenjojo");
            cc_reg_UG.Add("86", "Mayuge");
            cc_reg_UG.Add("87", "Mbale");
            cc_reg_UG.Add("88", "Moroto");
            cc_reg_UG.Add("89", "Mpigi");
            cc_reg_UG.Add("90", "Mukono");
            cc_reg_UG.Add("91", "Nakapiripirit");
            cc_reg_UG.Add("92", "Pader");
            cc_reg_UG.Add("93", "Rukungiri");
            cc_reg_UG.Add("94", "Sironko");
            cc_reg_UG.Add("95", "Soroti");
            cc_reg_UG.Add("96", "Wakiso");
            cc_reg_UG.Add("97", "Yumbe");
            GEOIP_REGION_NAME.Add("UG", cc_reg_UG);
            Hashtable cc_reg_US = new Hashtable();
            cc_reg_US.Add("AA", "Armed Forces Americas");
            cc_reg_US.Add("AE", "Armed Forces Europe, Middle East, & Canada");
            cc_reg_US.Add("AK", "Alaska");
            cc_reg_US.Add("AL", "Alabama");
            cc_reg_US.Add("AP", "Armed Forces Pacific");
            cc_reg_US.Add("AR", "Arkansas");
            cc_reg_US.Add("AS", "American Samoa");
            cc_reg_US.Add("AZ", "Arizona");
            cc_reg_US.Add("CA", "California");
            cc_reg_US.Add("CO", "Colorado");
            cc_reg_US.Add("CT", "Connecticut");
            cc_reg_US.Add("DC", "District of Columbia");
            cc_reg_US.Add("DE", "Delaware");
            cc_reg_US.Add("FL", "Florida");
            cc_reg_US.Add("FM", "Federated States of Micronesia");
            cc_reg_US.Add("GA", "Georgia");
            cc_reg_US.Add("GU", "Guam");
            cc_reg_US.Add("HI", "Hawaii");
            cc_reg_US.Add("IA", "Iowa");
            cc_reg_US.Add("ID", "Idaho");
            cc_reg_US.Add("IL", "Illinois");
            cc_reg_US.Add("IN", "Indiana");
            cc_reg_US.Add("KS", "Kansas");
            cc_reg_US.Add("KY", "Kentucky");
            cc_reg_US.Add("LA", "Louisiana");
            cc_reg_US.Add("MA", "Massachusetts");
            cc_reg_US.Add("MD", "Maryland");
            cc_reg_US.Add("ME", "Maine");
            cc_reg_US.Add("MH", "Marshall Islands");
            cc_reg_US.Add("MI", "Michigan");
            cc_reg_US.Add("MN", "Minnesota");
            cc_reg_US.Add("MO", "Missouri");
            cc_reg_US.Add("MP", "Northern Mariana Islands");
            cc_reg_US.Add("MS", "Mississippi");
            cc_reg_US.Add("MT", "Montana");
            cc_reg_US.Add("NC", "North Carolina");
            cc_reg_US.Add("ND", "North Dakota");
            cc_reg_US.Add("NE", "Nebraska");
            cc_reg_US.Add("NH", "New Hampshire");
            cc_reg_US.Add("NJ", "New Jersey");
            cc_reg_US.Add("NM", "New Mexico");
            cc_reg_US.Add("NV", "Nevada");
            cc_reg_US.Add("NY", "New York");
            cc_reg_US.Add("OH", "Ohio");
            cc_reg_US.Add("OK", "Oklahoma");
            cc_reg_US.Add("OR", "Oregon");
            cc_reg_US.Add("PA", "Pennsylvania");
            cc_reg_US.Add("PR", "Puerto Rico");
            cc_reg_US.Add("PW", "Palau");
            cc_reg_US.Add("RI", "Rhode Island");
            cc_reg_US.Add("SC", "South Carolina");
            cc_reg_US.Add("SD", "South Dakota");
            cc_reg_US.Add("TN", "Tennessee");
            cc_reg_US.Add("TX", "Texas");
            cc_reg_US.Add("UT", "Utah");
            cc_reg_US.Add("VA", "Virginia");
            cc_reg_US.Add("VI", "Virgin Islands");
            cc_reg_US.Add("VT", "Vermont");
            cc_reg_US.Add("WA", "Washington");
            cc_reg_US.Add("WI", "Wisconsin");
            cc_reg_US.Add("WV", "West Virginia");
            cc_reg_US.Add("WY", "Wyoming");
            GEOIP_REGION_NAME.Add("US", cc_reg_US);
            Hashtable cc_reg_UY = new Hashtable();
            cc_reg_UY.Add("01", "Artigas");
            cc_reg_UY.Add("02", "Canelones");
            cc_reg_UY.Add("03", "Cerro Largo");
            cc_reg_UY.Add("04", "Colonia");
            cc_reg_UY.Add("05", "Durazno");
            cc_reg_UY.Add("06", "Flores");
            cc_reg_UY.Add("07", "Florida");
            cc_reg_UY.Add("08", "Lavalleja");
            cc_reg_UY.Add("09", "Maldonado");
            cc_reg_UY.Add("10", "Montevideo");
            cc_reg_UY.Add("11", "Paysandu");
            cc_reg_UY.Add("12", "Rio Negro");
            cc_reg_UY.Add("13", "Rivera");
            cc_reg_UY.Add("14", "Rocha");
            cc_reg_UY.Add("15", "Salto");
            cc_reg_UY.Add("16", "San Jose");
            cc_reg_UY.Add("17", "Soriano");
            cc_reg_UY.Add("18", "Tacuarembo");
            cc_reg_UY.Add("19", "Treinta y Tres");
            GEOIP_REGION_NAME.Add("UY", cc_reg_UY);
            Hashtable cc_reg_UZ = new Hashtable();
            cc_reg_UZ.Add("01", "Andijon");
            cc_reg_UZ.Add("02", "Bukhoro");
            cc_reg_UZ.Add("03", "Farghona");
            cc_reg_UZ.Add("04", "Jizzakh");
            cc_reg_UZ.Add("05", "Khorazm");
            cc_reg_UZ.Add("06", "Namangan");
            cc_reg_UZ.Add("07", "Nawoiy");
            cc_reg_UZ.Add("08", "Qashqadaryo");
            cc_reg_UZ.Add("09", "Qoraqalpoghiston");
            cc_reg_UZ.Add("10", "Samarqand");
            cc_reg_UZ.Add("11", "Sirdaryo");
            cc_reg_UZ.Add("12", "Surkhondaryo");
            cc_reg_UZ.Add("13", "Toshkent");
            cc_reg_UZ.Add("14", "Toshkent");
            GEOIP_REGION_NAME.Add("UZ", cc_reg_UZ);
            Hashtable cc_reg_VC = new Hashtable();
            cc_reg_VC.Add("01", "Charlotte");
            cc_reg_VC.Add("02", "Saint Andrew");
            cc_reg_VC.Add("03", "Saint David");
            cc_reg_VC.Add("04", "Saint George");
            cc_reg_VC.Add("05", "Saint Patrick");
            cc_reg_VC.Add("06", "Grenadines");
            GEOIP_REGION_NAME.Add("VC", cc_reg_VC);
            Hashtable cc_reg_VE = new Hashtable();
            cc_reg_VE.Add("01", "Amazonas");
            cc_reg_VE.Add("02", "Anzoategui");
            cc_reg_VE.Add("03", "Apure");
            cc_reg_VE.Add("04", "Aragua");
            cc_reg_VE.Add("05", "Barinas");
            cc_reg_VE.Add("06", "Bolivar");
            cc_reg_VE.Add("07", "Carabobo");
            cc_reg_VE.Add("08", "Cojedes");
            cc_reg_VE.Add("09", "Delta Amacuro");
            cc_reg_VE.Add("11", "Falcon");
            cc_reg_VE.Add("12", "Guarico");
            cc_reg_VE.Add("13", "Lara");
            cc_reg_VE.Add("14", "Merida");
            cc_reg_VE.Add("15", "Miranda");
            cc_reg_VE.Add("16", "Monagas");
            cc_reg_VE.Add("17", "Nueva Esparta");
            cc_reg_VE.Add("18", "Portuguesa");
            cc_reg_VE.Add("19", "Sucre");
            cc_reg_VE.Add("20", "Tachira");
            cc_reg_VE.Add("21", "Trujillo");
            cc_reg_VE.Add("22", "Yaracuy");
            cc_reg_VE.Add("23", "Zulia");
            cc_reg_VE.Add("24", "Dependencias Federales");
            cc_reg_VE.Add("25", "Distrito Federal");
            cc_reg_VE.Add("26", "Vargas");
            GEOIP_REGION_NAME.Add("VE", cc_reg_VE);
            Hashtable cc_reg_VN = new Hashtable();
            cc_reg_VN.Add("01", "An Giang");
            cc_reg_VN.Add("03", "Ben Tre");
            cc_reg_VN.Add("05", "Cao Bang");
            cc_reg_VN.Add("09", "Dong Thap");
            cc_reg_VN.Add("13", "Hai Phong");
            cc_reg_VN.Add("20", "Ho Chi Minh");
            cc_reg_VN.Add("21", "Kien Giang");
            cc_reg_VN.Add("23", "Lam Dong");
            cc_reg_VN.Add("24", "Long An");
            cc_reg_VN.Add("30", "Quang Ninh");
            cc_reg_VN.Add("32", "Son La");
            cc_reg_VN.Add("33", "Tay Ninh");
            cc_reg_VN.Add("34", "Thanh Hoa");
            cc_reg_VN.Add("35", "Thai Binh");
            cc_reg_VN.Add("37", "Tien Giang");
            cc_reg_VN.Add("39", "Lang Son");
            cc_reg_VN.Add("43", "Dong Nai");
            cc_reg_VN.Add("44", "Ha Noi");
            cc_reg_VN.Add("45", "Ba Ria-Vung Tau");
            cc_reg_VN.Add("46", "Binh Dinh");
            cc_reg_VN.Add("47", "Binh Thuan");
            cc_reg_VN.Add("49", "Gia Lai");
            cc_reg_VN.Add("50", "Ha Giang");
            cc_reg_VN.Add("52", "Ha Tinh");
            cc_reg_VN.Add("53", "Hoa Binh");
            cc_reg_VN.Add("54", "Khanh Hoa");
            cc_reg_VN.Add("55", "Kon Tum");
            cc_reg_VN.Add("58", "Nghe An");
            cc_reg_VN.Add("59", "Ninh Binh");
            cc_reg_VN.Add("60", "Ninh Thuan");
            cc_reg_VN.Add("61", "Phu Yen");
            cc_reg_VN.Add("62", "Quang Binh");
            cc_reg_VN.Add("63", "Quang Ngai");
            cc_reg_VN.Add("64", "Quang Tri");
            cc_reg_VN.Add("65", "Soc Trang");
            cc_reg_VN.Add("66", "Thua Thien-Hue");
            cc_reg_VN.Add("67", "Tra Vinh");
            cc_reg_VN.Add("68", "Tuyen Quang");
            cc_reg_VN.Add("69", "Vinh Long");
            cc_reg_VN.Add("70", "Yen Bai");
            cc_reg_VN.Add("71", "Bac Giang");
            cc_reg_VN.Add("72", "Bac Kan");
            cc_reg_VN.Add("73", "Bac Lieu");
            cc_reg_VN.Add("74", "Bac Ninh");
            cc_reg_VN.Add("75", "Binh Duong");
            cc_reg_VN.Add("76", "Binh Phuoc");
            cc_reg_VN.Add("77", "Ca Mau");
            cc_reg_VN.Add("78", "Da Nang");
            cc_reg_VN.Add("79", "Hai Duong");
            cc_reg_VN.Add("80", "Ha Nam");
            cc_reg_VN.Add("81", "Hung Yen");
            cc_reg_VN.Add("82", "Nam Dinh");
            cc_reg_VN.Add("83", "Phu Tho");
            cc_reg_VN.Add("84", "Quang Nam");
            cc_reg_VN.Add("85", "Thai Nguyen");
            cc_reg_VN.Add("86", "Vinh Phuc");
            cc_reg_VN.Add("87", "Can Tho");
            cc_reg_VN.Add("88", "Dac Lak");
            cc_reg_VN.Add("89", "Lai Chau");
            cc_reg_VN.Add("90", "Lao Cai");
            cc_reg_VN.Add("91", "Dak Nong");
            cc_reg_VN.Add("92", "Dien Bien");
            cc_reg_VN.Add("93", "Hau Giang");
            GEOIP_REGION_NAME.Add("VN", cc_reg_VN);
            Hashtable cc_reg_VU = new Hashtable();
            cc_reg_VU.Add("05", "Ambrym");
            cc_reg_VU.Add("06", "Aoba");
            cc_reg_VU.Add("07", "Torba");
            cc_reg_VU.Add("08", "Efate");
            cc_reg_VU.Add("09", "Epi");
            cc_reg_VU.Add("10", "Malakula");
            cc_reg_VU.Add("11", "Paama");
            cc_reg_VU.Add("12", "Pentecote");
            cc_reg_VU.Add("13", "Sanma");
            cc_reg_VU.Add("14", "Shepherd");
            cc_reg_VU.Add("15", "Tafea");
            cc_reg_VU.Add("16", "Malampa");
            cc_reg_VU.Add("17", "Penama");
            cc_reg_VU.Add("18", "Shefa");
            GEOIP_REGION_NAME.Add("VU", cc_reg_VU);
            Hashtable cc_reg_WS = new Hashtable();
            cc_reg_WS.Add("02", "Aiga-i-le-Tai");
            cc_reg_WS.Add("03", "Atua");
            cc_reg_WS.Add("04", "Fa");
            cc_reg_WS.Add("05", "Gaga");
            cc_reg_WS.Add("06", "Va");
            cc_reg_WS.Add("07", "Gagaifomauga");
            cc_reg_WS.Add("08", "Palauli");
            cc_reg_WS.Add("09", "Satupa");
            cc_reg_WS.Add("10", "Tuamasaga");
            cc_reg_WS.Add("11", "Vaisigano");
            GEOIP_REGION_NAME.Add("WS", cc_reg_WS);
            Hashtable cc_reg_YE = new Hashtable();
            cc_reg_YE.Add("01", "Abyan");
            cc_reg_YE.Add("02", "Adan");
            cc_reg_YE.Add("03", "Al Mahrah");
            cc_reg_YE.Add("04", "Hadramawt");
            cc_reg_YE.Add("05", "Shabwah");
            cc_reg_YE.Add("06", "Lahij");
            cc_reg_YE.Add("07", "Al Bayda'");
            cc_reg_YE.Add("08", "Al Hudaydah");
            cc_reg_YE.Add("09", "Al Jawf");
            cc_reg_YE.Add("10", "Al Mahwit");
            cc_reg_YE.Add("11", "Dhamar");
            cc_reg_YE.Add("12", "Hajjah");
            cc_reg_YE.Add("13", "Ibb");
            cc_reg_YE.Add("14", "Ma'rib");
            cc_reg_YE.Add("15", "Sa'dah");
            cc_reg_YE.Add("16", "San'a'");
            cc_reg_YE.Add("17", "Taizz");
            cc_reg_YE.Add("18", "Ad Dali");
            cc_reg_YE.Add("19", "Amran");
            cc_reg_YE.Add("20", "Al Bayda'");
            cc_reg_YE.Add("21", "Al Jawf");
            cc_reg_YE.Add("22", "Hajjah");
            cc_reg_YE.Add("23", "Ibb");
            cc_reg_YE.Add("24", "Lahij");
            cc_reg_YE.Add("25", "Taizz");
            GEOIP_REGION_NAME.Add("YE", cc_reg_YE);
            Hashtable cc_reg_ZA = new Hashtable();
            cc_reg_ZA.Add("01", "North-Western Province");
            cc_reg_ZA.Add("02", "KwaZulu-Natal");
            cc_reg_ZA.Add("03", "Free State");
            cc_reg_ZA.Add("05", "Eastern Cape");
            cc_reg_ZA.Add("06", "Gauteng");
            cc_reg_ZA.Add("07", "Mpumalanga");
            cc_reg_ZA.Add("08", "Northern Cape");
            cc_reg_ZA.Add("09", "Limpopo");
            cc_reg_ZA.Add("10", "North-West");
            cc_reg_ZA.Add("11", "Western Cape");
            GEOIP_REGION_NAME.Add("ZA", cc_reg_ZA);
            Hashtable cc_reg_ZM = new Hashtable();
            cc_reg_ZM.Add("01", "Western");
            cc_reg_ZM.Add("02", "Central");
            cc_reg_ZM.Add("03", "Eastern");
            cc_reg_ZM.Add("04", "Luapula");
            cc_reg_ZM.Add("05", "Northern");
            cc_reg_ZM.Add("06", "North-Western");
            cc_reg_ZM.Add("07", "Southern");
            cc_reg_ZM.Add("08", "Copperbelt");
            cc_reg_ZM.Add("09", "Lusaka");
            GEOIP_REGION_NAME.Add("ZM", cc_reg_ZM);
            Hashtable cc_reg_ZW = new Hashtable();
            cc_reg_ZW.Add("01", "Manicaland");
            cc_reg_ZW.Add("02", "Midlands");
            cc_reg_ZW.Add("03", "Mashonaland Central");
            cc_reg_ZW.Add("04", "Mashonaland East");
            cc_reg_ZW.Add("05", "Mashonaland West");
            cc_reg_ZW.Add("06", "Matabeleland North");
            cc_reg_ZW.Add("07", "Matabeleland South");
            cc_reg_ZW.Add("08", "Masvingo");
            cc_reg_ZW.Add("09", "Bulawayo");
            cc_reg_ZW.Add("10", "Harare");
            GEOIP_REGION_NAME.Add("ZW", cc_reg_ZW);
        }
    }

    public class Location
    {
        public String countryCode;
        public String countryName;
        public String region;
        public String city;
        public String postalCode;
        public double latitude;
        public double longitude;
        public int dma_code;
        public int area_code;
        public String regionName;
        public int metro_code;

        private static double EARTH_DIAMETER = 2 * 6378.2;
        private static double PI = 3.14159265;
        private static double RAD_CONVERT = PI / 180;

        public double distance(Location loc)
        {
            double delta_lat, delta_lon;
            double temp;

            double lat1 = latitude;
            double lon1 = longitude;
            double lat2 = loc.latitude;
            double lon2 = loc.longitude;

            // convert degrees to radians
            lat1 *= RAD_CONVERT;
            lat2 *= RAD_CONVERT;

            // find the deltas
            delta_lat = lat2 - lat1;
            delta_lon = (lon2 - lon1) * RAD_CONVERT;

            // Find the great circle distance
            temp = Math.Pow(Math.Sin(delta_lat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(delta_lon / 2), 2);
            return EARTH_DIAMETER * Math.Atan2(Math.Sqrt(temp), Math.Sqrt(1 - temp));
        }
    }

    public class Region
    {
        public String countryCode;
        public String countryName;
        public String region;
        public Region()
        {
        }
        public Region(String countryCode, String countryName, String region)
        {
            this.countryCode = countryCode;
            this.countryName = countryName;
            this.region = region;
        }
        public String getcountryCode()
        {
            return countryCode;
        }
        public String getcountryName()
        {
            return countryName;
        }
        public String getregion()
        {
            return region;
        }
    }


    public class Country
    {

        private String code;
        private String name;

        /**
         * Creates a new Country.
         *
         * @param code the country code.
         * @param name the country name.
         */
        public Country(String code, String name)
        {
            this.code = code;
            this.name = name;
        }
        /**
          * Returns the ISO two-letter country code of this country.
          *
          * @return the country code.
          */
        public String getCode()
        {
            return code;
        }

        /**
         * Returns the name of this country.
         *
         * @return the country name.
         */
        public String getName()
        {
            return name;
        }
    }

    public class DatabaseInfo
    {

        public static int COUNTRY_EDITION = 1;
        public static int REGION_EDITION_REV0 = 7;
        public static int REGION_EDITION_REV1 = 3;
        public static int CITY_EDITION_REV0 = 6;
        public static int CITY_EDITION_REV1 = 2;
        public static int ORG_EDITION = 5;
        public static int ISP_EDITION = 4;
        public static int PROXY_EDITION = 8;
        public static int ASNUM_EDITION = 9;
        public static int NETSPEED_EDITION = 10;
        public static int DOMAIN_EDITION = 11;
        public static int COUNTRY_EDITION_V6 = 12;
        public static int ASNUM_EDITION_V6 = 21;
        public static int ISP_EDITION_V6 = 22;
        public static int ORG_EDITION_V6 = 23;
        public static int DOMAIN_EDITION_V6 = 24;
        public static int CITY_EDITION_REV1_V6 = 30;
        public static int CITY_EDITION_REV0_V6 = 31;
        public static int NETSPEED_EDITION_REV1 = 32;
        public static int NETSPEED_EDITION_REV1_V6 = 33;


        //private static SimpleDateFormat formatter = new SimpleDateFormat("yyyyMMdd");

        private String info;
        /**
          * Creates a new DatabaseInfo object given the database info String.
          * @param info
          */

        public DatabaseInfo(String info)
        {
            this.info = info;
        }

        public int getType()
        {
            if ((info == null) | (info == ""))
            {
                return COUNTRY_EDITION;
            }
            else
            {
                // Get the type code from the database info string and then
                // subtract 105 from the value to preserve compatability with
                // databases from April 2003 and earlier.
                return Convert.ToInt32(info.Substring(4, 3)) - 105;
            }
        }

        /**
         * Returns true if the database is the premium version.
         *
         * @return true if the premium version of the database.
         */
        public bool isPremium()
        {
            return info.IndexOf("FREE") < 0;
        }

        /**
         * Returns the date of the database.
         *
         * @return the date of the database.
         */
        public DateTime getDate()
        {
            for (int i = 0; i < info.Length - 9; i++)
            {
                if (Char.IsWhiteSpace(info[i]) == true)
                {
                    String dateString = info.Substring(i + 1, 8);
                    try
                    {
                        //synchronized (formatter) {
                        return DateTime.ParseExact(dateString, "yyyyMMdd", null);
                        //}
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                    }
                    break;
                }
            }
            return DateTime.Now;
        }

        public String toString()
        {
            return info;
        }
    }

    public class LookupService
    {
        private FileStream file = null;
        private DatabaseInfo databaseInfo = null;
        private Object ioLock = new Object();
        byte databaseType = Convert.ToByte(DatabaseInfo.COUNTRY_EDITION);
        int[] databaseSegments;
        int recordLength;
        int dboptions;
        byte[] dbbuffer;

        String licenseKey;
        int dnsService = 0;
        private static Country UNKNOWN_COUNTRY = new Country("--", "N/A");
        private static int COUNTRY_BEGIN = 16776960;
        private static int STATE_BEGIN = 16700000;
        private static int STRUCTURE_INFO_MAX_SIZE = 20;
        private static int DATABASE_INFO_MAX_SIZE = 100;
        private static int FULL_RECORD_LENGTH = 100;//???
        private static int SEGMENT_RECORD_LENGTH = 3;
        private static int STANDARD_RECORD_LENGTH = 3;
        private static int ORG_RECORD_LENGTH = 4;
        private static int MAX_RECORD_LENGTH = 4;
        private static int MAX_ORG_RECORD_LENGTH = 1000;//???
        private static int FIPS_RANGE = 360;
        private static int STATE_BEGIN_REV0 = 16700000;
        private static int STATE_BEGIN_REV1 = 16000000;
        private static int US_OFFSET = 1;
        private static int CANADA_OFFSET = 677;
        private static int WORLD_OFFSET = 1353;
        public static int GEOIP_STANDARD = 0;
        public static int GEOIP_MEMORY_CACHE = 1;
        public static int GEOIP_UNKNOWN_SPEED = 0;
        public static int GEOIP_DIALUP_SPEED = 1;
        public static int GEOIP_CABLEDSL_SPEED = 2;
        public static int GEOIP_CORPORATE_SPEED = 3;

        private static String[] countryCode = {
   "--","AP","EU","AD","AE","AF","AG","AI","AL","AM","CW",
	"AO","AQ","AR","AS","AT","AU","AW","AZ","BA","BB",
	"BD","BE","BF","BG","BH","BI","BJ","BM","BN","BO",
	"BR","BS","BT","BV","BW","BY","BZ","CA","CC","CD",
	"CF","CG","CH","CI","CK","CL","CM","CN","CO","CR",
	"CU","CV","CX","CY","CZ","DE","DJ","DK","DM","DO",
	"DZ","EC","EE","EG","EH","ER","ES","ET","FI","FJ",
	"FK","FM","FO","FR","SX","GA","GB","GD","GE","GF",
	"GH","GI","GL","GM","GN","GP","GQ","GR","GS","GT",
	"GU","GW","GY","HK","HM","HN","HR","HT","HU","ID",
	"IE","IL","IN","IO","IQ","IR","IS","IT","JM","JO",
	"JP","KE","KG","KH","KI","KM","KN","KP","KR","KW",
	"KY","KZ","LA","LB","LC","LI","LK","LR","LS","LT",
	"LU","LV","LY","MA","MC","MD","MG","MH","MK","ML",
	"MM","MN","MO","MP","MQ","MR","MS","MT","MU","MV",
	"MW","MX","MY","MZ","NA","NC","NE","NF","NG","NI",
	"NL","NO","NP","NR","NU","NZ","OM","PA","PE","PF",
	"PG","PH","PK","PL","PM","PN","PR","PS","PT","PW",
	"PY","QA","RE","RO","RU","RW","SA","SB","SC","SD",
	"SE","SG","SH","SI","SJ","SK","SL","SM","SN","SO",
	"SR","ST","SV","SY","SZ","TC","TD","TF","TG","TH",
	"TJ","TK","TM","TN","TO","TL","TR","TT","TV","TW",
	"TZ","UA","UG","UM","US","UY","UZ","VA","VC","VE",
	"VG","VI","VN","VU","WF","WS","YE","YT","RS","ZA",
	"ZM","ME","ZW","A1","A2","O1","AX","GG","IM","JE",
        "BL","MF", "BQ", "SS", "O1"
	};

        private static String[] countryName = {
        "N/A","Asia/Pacific Region","Europe","Andorra","United Arab Emirates","Afghanistan","Antigua and Barbuda","Anguilla","Albania","Armenia","Curacao",
	"Angola","Antarctica","Argentina","American Samoa","Austria","Australia","Aruba","Azerbaijan","Bosnia and Herzegovina","Barbados",
	"Bangladesh","Belgium","Burkina Faso","Bulgaria","Bahrain","Burundi","Benin","Bermuda","Brunei Darussalam","Bolivia",
	"Brazil","Bahamas","Bhutan","Bouvet Island","Botswana","Belarus","Belize","Canada","Cocos (Keeling) Islands","Congo, The Democratic Republic of the",
	"Central African Republic","Congo","Switzerland","Cote D'Ivoire","Cook Islands","Chile","Cameroon","China","Colombia","Costa Rica",
	"Cuba","Cape Verde","Christmas Island","Cyprus","Czech Republic","Germany","Djibouti","Denmark","Dominica","Dominican Republic",
	"Algeria","Ecuador","Estonia","Egypt","Western Sahara","Eritrea","Spain","Ethiopia","Finland","Fiji",
	"Falkland Islands (Malvinas)","Micronesia, Federated States of","Faroe Islands","France","Sint Maarten (Dutch part)","Gabon","United Kingdom","Grenada","Georgia","French Guiana",
	"Ghana","Gibraltar","Greenland","Gambia","Guinea","Guadeloupe","Equatorial Guinea","Greece","South Georgia and the South Sandwich Islands","Guatemala",
	"Guam","Guinea-Bissau","Guyana","Hong Kong","Heard Island and McDonald Islands","Honduras","Croatia","Haiti","Hungary","Indonesia",
	"Ireland","Israel","India","British Indian Ocean Territory","Iraq","Iran, Islamic Republic of","Iceland","Italy","Jamaica","Jordan",
	"Japan","Kenya","Kyrgyzstan","Cambodia","Kiribati","Comoros","Saint Kitts and Nevis","Korea, Democratic People's Republic of","Korea, Republic of","Kuwait",
	"Cayman Islands","Kazakhstan","Lao People's Democratic Republic","Lebanon","Saint Lucia","Liechtenstein","Sri Lanka","Liberia","Lesotho","Lithuania",
	"Luxembourg","Latvia","Libya","Morocco","Monaco","Moldova, Republic of","Madagascar","Marshall Islands","Macedonia","Mali",
	"Myanmar","Mongolia","Macau","Northern Mariana Islands","Martinique","Mauritania","Montserrat","Malta","Mauritius","Maldives",
	"Malawi","Mexico","Malaysia","Mozambique","Namibia","New Caledonia","Niger","Norfolk Island","Nigeria","Nicaragua",
	"Netherlands","Norway","Nepal","Nauru","Niue","New Zealand","Oman","Panama","Peru","French Polynesia",
	"Papua New Guinea","Philippines","Pakistan","Poland","Saint Pierre and Miquelon","Pitcairn Islands","Puerto Rico","Palestinian Territory","Portugal","Palau",
	"Paraguay","Qatar","Reunion","Romania","Russian Federation","Rwanda","Saudi Arabia","Solomon Islands","Seychelles","Sudan",
	"Sweden","Singapore","Saint Helena","Slovenia","Svalbard and Jan Mayen","Slovakia","Sierra Leone","San Marino","Senegal","Somalia","Suriname",
	"Sao Tome and Principe","El Salvador","Syrian Arab Republic","Swaziland","Turks and Caicos Islands","Chad","French Southern Territories","Togo","Thailand",
	"Tajikistan","Tokelau","Turkmenistan","Tunisia","Tonga","Timor-Leste","Turkey","Trinidad and Tobago","Tuvalu","Taiwan",
	"Tanzania, United Republic of","Ukraine","Uganda","United States Minor Outlying Islands","United States","Uruguay","Uzbekistan","Holy See (Vatican City State)","Saint Vincent and the Grenadines","Venezuela",
	"Virgin Islands, British","Virgin Islands, U.S.","Vietnam","Vanuatu","Wallis and Futuna","Samoa","Yemen","Mayotte","Serbia","South Africa",
	"Zambia","Montenegro","Zimbabwe","Anonymous Proxy","Satellite Provider","Other","Aland Islands","Guernsey","Isle of Man","Jersey",
  "Saint Barthelemy","Saint Martin", "Bonaire, Saint Eustatius and Saba", "South Sudan", "Other"};

        public LookupService(String databaseFile, int options)
        {
            try
            {
                lock (ioLock)
                {
                    this.file = new FileStream(databaseFile, FileMode.Open, FileAccess.Read);
                }
                dboptions = options;
                init();
            }
            catch (System.SystemException)
            {
                Console.Write("cannot open file " + databaseFile + "\n");
            }
        }

        public LookupService(String databaseFile)
            : this(databaseFile, GEOIP_STANDARD)
        {
        }

        private void init()
        {
            int i, j;
            byte[] delim = new byte[3];
            byte[] buf = new byte[SEGMENT_RECORD_LENGTH];
            databaseType = (byte)DatabaseInfo.COUNTRY_EDITION;
            recordLength = STANDARD_RECORD_LENGTH;
            //file.Seek(file.Length() - 3,SeekOrigin.Begin);
            lock (ioLock)
            {
                file.Seek(-3, SeekOrigin.End);
                for (i = 0; i < STRUCTURE_INFO_MAX_SIZE; i++)
                {
                    file.Read(delim, 0, 3);
                    if (delim[0] == 255 && delim[1] == 255 && delim[2] == 255)
                    {
                        databaseType = Convert.ToByte(file.ReadByte());
                        if (databaseType >= 106)
                        {
                            // Backward compatibility with databases from April 2003 and earlier
                            databaseType -= 105;
                        }
                        // Determine the database type.
                        if (databaseType == DatabaseInfo.REGION_EDITION_REV0)
                        {
                            databaseSegments = new int[1];
                            databaseSegments[0] = STATE_BEGIN_REV0;
                            recordLength = STANDARD_RECORD_LENGTH;
                        }
                        else if (databaseType == DatabaseInfo.REGION_EDITION_REV1)
                        {
                            databaseSegments = new int[1];
                            databaseSegments[0] = STATE_BEGIN_REV1;
                            recordLength = STANDARD_RECORD_LENGTH;
                        }
                        else if (databaseType == DatabaseInfo.CITY_EDITION_REV0 ||
                              databaseType == DatabaseInfo.CITY_EDITION_REV1 ||
                              databaseType == DatabaseInfo.ORG_EDITION ||
                              databaseType == DatabaseInfo.ORG_EDITION_V6 ||
                              databaseType == DatabaseInfo.ISP_EDITION ||
                              databaseType == DatabaseInfo.ISP_EDITION_V6 ||
                              databaseType == DatabaseInfo.ASNUM_EDITION ||
                              databaseType == DatabaseInfo.ASNUM_EDITION_V6 ||
                              databaseType == DatabaseInfo.NETSPEED_EDITION_REV1 ||
                  databaseType == DatabaseInfo.NETSPEED_EDITION_REV1_V6 ||
                              databaseType == DatabaseInfo.CITY_EDITION_REV0_V6 ||
                  databaseType == DatabaseInfo.CITY_EDITION_REV1_V6
                              )
                        {
                            databaseSegments = new int[1];
                            databaseSegments[0] = 0;
                            if (databaseType == DatabaseInfo.CITY_EDITION_REV0 ||
                                databaseType == DatabaseInfo.CITY_EDITION_REV1 ||
                                databaseType == DatabaseInfo.ASNUM_EDITION_V6 ||
                                databaseType == DatabaseInfo.NETSPEED_EDITION_REV1 ||
                        databaseType == DatabaseInfo.NETSPEED_EDITION_REV1_V6 ||
                                databaseType == DatabaseInfo.CITY_EDITION_REV0_V6 ||
                            databaseType == DatabaseInfo.CITY_EDITION_REV1_V6 ||
                                databaseType == DatabaseInfo.ASNUM_EDITION
                                )
                            {
                                recordLength = STANDARD_RECORD_LENGTH;
                            }
                            else
                            {
                                recordLength = ORG_RECORD_LENGTH;
                            }
                            file.Read(buf, 0, SEGMENT_RECORD_LENGTH);
                            for (j = 0; j < SEGMENT_RECORD_LENGTH; j++)
                            {
                                databaseSegments[0] += (unsignedByteToInt(buf[j]) << (j * 8));
                            }
                        }
                        break;
                    }
                    else
                    {
                        //file.Seek(file.getFilePointer() - 4);
                        file.Seek(-4, SeekOrigin.Current);
                        //file.Seek(file.position-4,SeekOrigin.Begin);
                    }
                }
                if ((databaseType == DatabaseInfo.COUNTRY_EDITION) ||
                  (databaseType == DatabaseInfo.COUNTRY_EDITION_V6) ||
                    (databaseType == DatabaseInfo.PROXY_EDITION) ||
                    (databaseType == DatabaseInfo.NETSPEED_EDITION))
                {
                    databaseSegments = new int[1];
                    databaseSegments[0] = COUNTRY_BEGIN;
                    recordLength = STANDARD_RECORD_LENGTH;
                }
                if ((dboptions & GEOIP_MEMORY_CACHE) == 1)
                {
                    int l = (int)file.Length;
                    dbbuffer = new byte[l];
                    file.Seek(0, SeekOrigin.Begin);
                    file.Read(dbbuffer, 0, l);
                }
            }
        }
        public void close()
        {
            try
            {
                lock (ioLock) { file.Close(); }
                file = null;
            }
            catch (Exception) { }
        }
        public Country getCountry(IPAddress ipAddress)
        {
            return getCountry(bytestoLong(ipAddress.GetAddressBytes()));
        }
        public Country getCountryV6(String ipAddress)
        {
            IPAddress addr;
            try
            {
                addr = IPAddress.Parse(ipAddress);
            }
            //catch (UnknownHostException e) {
            catch (Exception e)
            {
                Console.Write(e.Message);
                return UNKNOWN_COUNTRY;
            }
            return getCountryV6(addr);
        }
        public Country getCountry(String ipAddress)
        {
            IPAddress addr;
            try
            {
                addr = IPAddress.Parse(ipAddress);
            }
            //catch (UnknownHostException e) {
            catch (Exception e)
            {
                Console.Write(e.Message);
                return UNKNOWN_COUNTRY;
            }
            //  return getCountry(bytestoLong(addr.GetAddressBytes()));
            return getCountry(bytestoLong(addr.GetAddressBytes()));
        }
        public Country getCountryV6(IPAddress ipAddress)
        {
            if (file == null)
            {
                //throw new IllegalStateException("Database has been closed.");
                throw new Exception("Database has been closed.");
            }
            if ((databaseType == DatabaseInfo.CITY_EDITION_REV1) |
            (databaseType == DatabaseInfo.CITY_EDITION_REV0))
            {
                Location l = getLocation(ipAddress);
                if (l == null)
                {
                    return UNKNOWN_COUNTRY;
                }
                else
                {
                    return new Country(l.countryCode, l.countryName);
                }
            }
            else
            {
                int ret = SeekCountryV6(ipAddress) - COUNTRY_BEGIN;
                if (ret == 0)
                {
                    return UNKNOWN_COUNTRY;
                }
                else
                {
                    return new Country(countryCode[ret], countryName[ret]);
                }
            }
        }

        public Country getCountry(long ipAddress)
        {
            if (file == null)
            {
                //throw new IllegalStateException("Database has been closed.");
                throw new Exception("Database has been closed.");
            }
            if ((databaseType == DatabaseInfo.CITY_EDITION_REV1) |
            (databaseType == DatabaseInfo.CITY_EDITION_REV0))
            {
                Location l = getLocation(ipAddress);
                if (l == null)
                {
                    return UNKNOWN_COUNTRY;
                }
                else
                {
                    return new Country(l.countryCode, l.countryName);
                }
            }
            else
            {
                int ret = SeekCountry(ipAddress) - COUNTRY_BEGIN;
                if (ret == 0)
                {
                    return UNKNOWN_COUNTRY;
                }
                else
                {
                    return new Country(countryCode[ret], countryName[ret]);
                }
            }
        }

        public int getID(String ipAddress)
        {
            IPAddress addr;
            try
            {
                addr = IPAddress.Parse(ipAddress);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return 0;
            }
            return getID(bytestoLong(addr.GetAddressBytes()));
        }

        public int getID(IPAddress ipAddress)
        {

            return getID(bytestoLong(ipAddress.GetAddressBytes()));
        }

        public int getID(long ipAddress)
        {
            if (file == null)
            {
                throw new Exception("Database has been closed.");
            }
            int ret = SeekCountry(ipAddress) - databaseSegments[0];
            return ret;
        }
        public DatabaseInfo getDatabaseInfo()
        {
            if (databaseInfo != null)
            {
                return databaseInfo;
            }
            try
            {
                // Synchronize since we're accessing the database file.
                lock (ioLock)
                {
                    bool hasStructureInfo = false;
                    byte[] delim = new byte[3];
                    // Advance to part of file where database info is stored.
                    file.Seek(-3, SeekOrigin.End);
                    for (int i = 0; i < STRUCTURE_INFO_MAX_SIZE; i++)
                    {
                        file.Read(delim, 0, 3);
                        if (delim[0] == 255 && delim[1] == 255 && delim[2] == 255)
                        {
                            hasStructureInfo = true;
                            break;
                        }
                        file.Seek(-4, SeekOrigin.Current);
                    }
                    if (hasStructureInfo)
                    {
                        file.Seek(-6, SeekOrigin.Current);
                    }
                    else
                    {
                        // No structure info, must be pre Sep 2002 database, go back to end.
                        file.Seek(-3, SeekOrigin.End);
                    }
                    // Find the database info string.
                    for (int i = 0; i < DATABASE_INFO_MAX_SIZE; i++)
                    {
                        file.Read(delim, 0, 3);
                        if (delim[0] == 0 && delim[1] == 0 && delim[2] == 0)
                        {
                            byte[] dbInfo = new byte[i];
                            char[] dbInfo2 = new char[i];
                            file.Read(dbInfo, 0, i);
                            for (int a0 = 0; a0 < i; a0++)
                            {
                                dbInfo2[a0] = Convert.ToChar(dbInfo[a0]);
                            }
                            // Create the database info object using the string.
                            this.databaseInfo = new DatabaseInfo(new String(dbInfo2));
                            return databaseInfo;
                        }
                        file.Seek(-4, SeekOrigin.Current);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                //e.printStackTrace();
            }
            return new DatabaseInfo("");
        }
        public Region getRegion(IPAddress ipAddress)
        {
            return getRegion(bytestoLong(ipAddress.GetAddressBytes()));
        }
        public Region getRegion(String str)
        {
            IPAddress addr;
            try
            {
                addr = IPAddress.Parse(str);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return null;
            }

            return getRegion(bytestoLong(addr.GetAddressBytes()));
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public Region getRegion(long ipnum)
        {
            Region record = new Region();
            int seek_region = 0;
            if (databaseType == DatabaseInfo.REGION_EDITION_REV0)
            {
                seek_region = SeekCountry(ipnum) - STATE_BEGIN_REV0;
                char[] ch = new char[2];
                if (seek_region >= 1000)
                {
                    record.countryCode = "US";
                    record.countryName = "United States";
                    ch[0] = (char)(((seek_region - 1000) / 26) + 65);
                    ch[1] = (char)(((seek_region - 1000) % 26) + 65);
                    record.region = new String(ch);
                }
                else
                {
                    record.countryCode = countryCode[seek_region];
                    record.countryName = countryName[seek_region];
                    record.region = "";
                }
            }
            else if (databaseType == DatabaseInfo.REGION_EDITION_REV1)
            {
                seek_region = SeekCountry(ipnum) - STATE_BEGIN_REV1;
                char[] ch = new char[2];
                if (seek_region < US_OFFSET)
                {
                    record.countryCode = "";
                    record.countryName = "";
                    record.region = "";
                }
                else if (seek_region < CANADA_OFFSET)
                {
                    record.countryCode = "US";
                    record.countryName = "United States";
                    ch[0] = (char)(((seek_region - US_OFFSET) / 26) + 65);
                    ch[1] = (char)(((seek_region - US_OFFSET) % 26) + 65);
                    record.region = new String(ch);
                }
                else if (seek_region < WORLD_OFFSET)
                {
                    record.countryCode = "CA";
                    record.countryName = "Canada";
                    ch[0] = (char)(((seek_region - CANADA_OFFSET) / 26) + 65);
                    ch[1] = (char)(((seek_region - CANADA_OFFSET) % 26) + 65);
                    record.region = new String(ch);
                }
                else
                {
                    record.countryCode = countryCode[(seek_region - WORLD_OFFSET) / FIPS_RANGE];
                    record.countryName = countryName[(seek_region - WORLD_OFFSET) / FIPS_RANGE];
                    record.region = "";
                }
            }
            return record;
        }
        public Location getLocation(IPAddress addr)
        {
            return getLocation(bytestoLong(addr.GetAddressBytes()));
        }
        public Location getLocationV6(String str)
        {
            IPAddress addr;
            try
            {
                addr = IPAddress.Parse(str);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return null;
            }

            return getLocationV6(addr);
        }

        public Location getLocation(String str)
        {
            IPAddress addr;
            try
            {
                addr = IPAddress.Parse(str);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return null;
            }

            return getLocation(bytestoLong(addr.GetAddressBytes()));
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public Location getLocationV6(IPAddress addr)
        {
            int record_pointer;
            byte[] record_buf = new byte[FULL_RECORD_LENGTH];
            char[] record_buf2 = new char[FULL_RECORD_LENGTH];
            int record_buf_offset = 0;
            Location record = new Location();
            int str_length = 0;
            int j, Seek_country;
            double latitude = 0, longitude = 0;

            try
            {
                Seek_country = SeekCountryV6(addr);
                if (Seek_country == databaseSegments[0])
                {
                    return null;
                }
                record_pointer = Seek_country + ((2 * recordLength - 1) * databaseSegments[0]);
                if ((dboptions & GEOIP_MEMORY_CACHE) == 1)
                {
                    Array.Copy(dbbuffer, record_pointer, record_buf, 0, Math.Min(dbbuffer.Length - record_pointer, FULL_RECORD_LENGTH));
                }
                else
                {
                    lock (ioLock)
                    {
                        file.Seek(record_pointer, SeekOrigin.Begin);
                        file.Read(record_buf, 0, FULL_RECORD_LENGTH);
                    }
                }
                for (int a0 = 0; a0 < FULL_RECORD_LENGTH; a0++)
                {
                    record_buf2[a0] = Convert.ToChar(record_buf[a0]);
                }
                // get country
                record.countryCode = countryCode[unsignedByteToInt(record_buf[0])];
                record.countryName = countryName[unsignedByteToInt(record_buf[0])];
                record_buf_offset++;

                // get region
                while (record_buf[record_buf_offset + str_length] != '\0')
                    str_length++;
                if (str_length > 0)
                {
                    record.region = new String(record_buf2, record_buf_offset, str_length);
                }
                record_buf_offset += str_length + 1;
                str_length = 0;

                // get region_name
                record.regionName = RegionName.getRegionName(record.countryCode, record.region);

                // get city
                while (record_buf[record_buf_offset + str_length] != '\0')
                    str_length++;
                if (str_length > 0)
                {
                    record.city = new String(record_buf2, record_buf_offset, str_length);
                }
                record_buf_offset += (str_length + 1);
                str_length = 0;

                // get postal code
                while (record_buf[record_buf_offset + str_length] != '\0')
                    str_length++;
                if (str_length > 0)
                {
                    record.postalCode = new String(record_buf2, record_buf_offset, str_length);
                }
                record_buf_offset += (str_length + 1);

                // get latitude
                for (j = 0; j < 3; j++)
                    latitude += (unsignedByteToInt(record_buf[record_buf_offset + j]) << (j * 8));
                record.latitude = (float)latitude / 10000 - 180;
                record_buf_offset += 3;

                // get longitude
                for (j = 0; j < 3; j++)
                    longitude += (unsignedByteToInt(record_buf[record_buf_offset + j]) << (j * 8));
                record.longitude = (float)longitude / 10000 - 180;

                record.metro_code = record.dma_code = 0;
                record.area_code = 0;
                if (databaseType == DatabaseInfo.CITY_EDITION_REV1
                  || databaseType == DatabaseInfo.CITY_EDITION_REV1_V6)
                {
                    // get metro_code
                    int metroarea_combo = 0;
                    if (record.countryCode == "US")
                    {
                        record_buf_offset += 3;
                        for (j = 0; j < 3; j++)
                            metroarea_combo += (unsignedByteToInt(record_buf[record_buf_offset + j]) << (j * 8));
                        record.metro_code = record.dma_code = metroarea_combo / 1000;
                        record.area_code = metroarea_combo % 1000;
                    }
                }
            }
            catch (IOException)
            {
                Console.Write("IO Exception while seting up segments");
            }
            return record;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public Location getLocation(long ipnum)
        {
            int record_pointer;
            byte[] record_buf = new byte[FULL_RECORD_LENGTH];
            char[] record_buf2 = new char[FULL_RECORD_LENGTH];
            int record_buf_offset = 0;
            Location record = new Location();
            int str_length = 0;
            int j, Seek_country;
            double latitude = 0, longitude = 0;

            try
            {
                Seek_country = SeekCountry(ipnum);
                if (Seek_country == databaseSegments[0])
                {
                    return null;
                }
                record_pointer = Seek_country + ((2 * recordLength - 1) * databaseSegments[0]);
                if ((dboptions & GEOIP_MEMORY_CACHE) == 1)
                {
                    Array.Copy(dbbuffer, record_pointer, record_buf, 0, Math.Min(dbbuffer.Length - record_pointer, FULL_RECORD_LENGTH));
                }
                else
                {
                    lock (ioLock)
                    {
                        file.Seek(record_pointer, SeekOrigin.Begin);
                        file.Read(record_buf, 0, FULL_RECORD_LENGTH);
                    }
                }
                for (int a0 = 0; a0 < FULL_RECORD_LENGTH; a0++)
                {
                    record_buf2[a0] = Convert.ToChar(record_buf[a0]);
                }
                // get country
                record.countryCode = countryCode[unsignedByteToInt(record_buf[0])];
                record.countryName = countryName[unsignedByteToInt(record_buf[0])];
                record_buf_offset++;

                // get region
                while (record_buf[record_buf_offset + str_length] != '\0')
                    str_length++;
                if (str_length > 0)
                {
                    record.region = new String(record_buf2, record_buf_offset, str_length);
                }
                record_buf_offset += str_length + 1;
                str_length = 0;

                // get region_name
                record.regionName = RegionName.getRegionName(record.countryCode, record.region);

                // get city
                while (record_buf[record_buf_offset + str_length] != '\0')
                    str_length++;
                if (str_length > 0)
                {
                    record.city = new String(record_buf2, record_buf_offset, str_length);
                }
                record_buf_offset += (str_length + 1);
                str_length = 0;

                // get postal code
                while (record_buf[record_buf_offset + str_length] != '\0')
                    str_length++;
                if (str_length > 0)
                {
                    record.postalCode = new String(record_buf2, record_buf_offset, str_length);
                }
                record_buf_offset += (str_length + 1);

                // get latitude
                for (j = 0; j < 3; j++)
                    latitude += (unsignedByteToInt(record_buf[record_buf_offset + j]) << (j * 8));
                record.latitude = (float)latitude / 10000 - 180;
                record_buf_offset += 3;

                // get longitude
                for (j = 0; j < 3; j++)
                    longitude += (unsignedByteToInt(record_buf[record_buf_offset + j]) << (j * 8));
                record.longitude = (float)longitude / 10000 - 180;

                record.metro_code = record.dma_code = 0;
                record.area_code = 0;
                if (databaseType == DatabaseInfo.CITY_EDITION_REV1)
                {
                    // get metro_code
                    int metroarea_combo = 0;
                    if (record.countryCode == "US")
                    {
                        record_buf_offset += 3;
                        for (j = 0; j < 3; j++)
                            metroarea_combo += (unsignedByteToInt(record_buf[record_buf_offset + j]) << (j * 8));
                        record.metro_code = record.dma_code = metroarea_combo / 1000;
                        record.area_code = metroarea_combo % 1000;
                    }
                }
            }
            catch (IOException)
            {
                Console.Write("IO Exception while seting up segments");
            }
            return record;
        }
        public String getOrg(IPAddress addr)
        {
            return getOrg(bytestoLong(addr.GetAddressBytes()));
        }

        public String getOrgV6(String str)
        {
            IPAddress addr;
            try
            {
                addr = IPAddress.Parse(str);
            }
            //catch (UnknownHostException e) {
            catch (Exception e)
            {
                Console.Write(e.Message);
                return null;
            }
            return getOrgV6(addr);
        }

        public String getOrg(String str)
        {
            IPAddress addr;
            try
            {
                addr = IPAddress.Parse(str);
            }
            //catch (UnknownHostException e) {
            catch (Exception e)
            {
                Console.Write(e.Message);
                return null;
            }
            return getOrg(bytestoLong(addr.GetAddressBytes()));
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public String getOrgV6(IPAddress addr)
        {
            int Seek_org;
            int record_pointer;
            int str_length = 0;
            byte[] buf = new byte[MAX_ORG_RECORD_LENGTH];
            char[] buf2 = new char[MAX_ORG_RECORD_LENGTH];
            String org_buf;

            try
            {
                Seek_org = SeekCountryV6(addr);
                if (Seek_org == databaseSegments[0])
                {
                    return null;
                }

                record_pointer = Seek_org + (2 * recordLength - 1) * databaseSegments[0];
                if ((dboptions & GEOIP_MEMORY_CACHE) == 1)
                {
                    Array.Copy(dbbuffer, record_pointer, buf, 0, Math.Min(dbbuffer.Length - record_pointer, MAX_ORG_RECORD_LENGTH));
                }
                else
                {
                    lock (ioLock)
                    {
                        file.Seek(record_pointer, SeekOrigin.Begin);
                        file.Read(buf, 0, MAX_ORG_RECORD_LENGTH);
                    }
                }
                while (buf[str_length] != 0)
                {
                    buf2[str_length] = Convert.ToChar(buf[str_length]);
                    str_length++;
                }
                buf2[str_length] = '\0';
                org_buf = new String(buf2, 0, str_length);
                return org_buf;
            }
            catch (IOException)
            {
                Console.Write("IO Exception");
                return null;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public String getOrg(long ipnum)
        {
            int Seek_org;
            int record_pointer;
            int str_length = 0;
            byte[] buf = new byte[MAX_ORG_RECORD_LENGTH];
            char[] buf2 = new char[MAX_ORG_RECORD_LENGTH];
            String org_buf;

            try
            {
                Seek_org = SeekCountry(ipnum);
                if (Seek_org == databaseSegments[0])
                {
                    return null;
                }

                record_pointer = Seek_org + (2 * recordLength - 1) * databaseSegments[0];
                if ((dboptions & GEOIP_MEMORY_CACHE) == 1)
                {
                    Array.Copy(dbbuffer, record_pointer, buf, 0, Math.Min(dbbuffer.Length - record_pointer, MAX_ORG_RECORD_LENGTH));
                }
                else
                {
                    lock (ioLock)
                    {
                        file.Seek(record_pointer, SeekOrigin.Begin);
                        file.Read(buf, 0, MAX_ORG_RECORD_LENGTH);
                    }
                }
                while (buf[str_length] != 0)
                {
                    buf2[str_length] = Convert.ToChar(buf[str_length]);
                    str_length++;
                }
                buf2[str_length] = '\0';
                org_buf = new String(buf2, 0, str_length);
                return org_buf;
            }
            catch (IOException)
            {
                Console.Write("IO Exception");
                return null;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private int SeekCountryV6(IPAddress ipAddress)
        {
            byte[] v6vec = ipAddress.GetAddressBytes();
            byte[] buf = new byte[2 * MAX_RECORD_LENGTH];
            int[] x = new int[2];
            int offset = 0;
            for (int depth = 127; depth >= 0; depth--)
            {
                try
                {
                    if ((dboptions & GEOIP_MEMORY_CACHE) == 1)
                    {
                        for (int i = 0; i < (2 * MAX_RECORD_LENGTH); i++)
                        {
                            buf[i] = dbbuffer[i + (2 * recordLength * offset)];
                        }
                    }
                    else
                    {
                        lock (ioLock)
                        {
                            file.Seek(2 * recordLength * offset, SeekOrigin.Begin);
                            file.Read(buf, 0, 2 * MAX_RECORD_LENGTH);
                        }
                    }
                }
                catch (IOException)
                {
                    Console.Write("IO Exception");
                }
                for (int i = 0; i < 2; i++)
                {
                    x[i] = 0;
                    for (int j = 0; j < recordLength; j++)
                    {
                        int y = buf[(i * recordLength) + j];
                        if (y < 0)
                        {
                            y += 256;
                        }
                        x[i] += (y << (j * 8));
                    }
                }


                int bnum = 127 - depth;
                int idx = bnum >> 3;
                int b_mask = 1 << (bnum & 7 ^ 7);
                if ((v6vec[idx] & b_mask) > 0)
                {
                    if (x[1] >= databaseSegments[0])
                    {
                        return x[1];
                    }
                    offset = x[1];
                }
                else
                {
                    if (x[0] >= databaseSegments[0])
                    {
                        return x[0];
                    }
                    offset = x[0];
                }
            }

            // shouldn't reach here
            Console.Write("Error Seeking country while Seeking " + ipAddress);
            return 0;

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private int SeekCountry(long ipAddress)
        {
            byte[] buf = new byte[2 * MAX_RECORD_LENGTH];
            int[] x = new int[2];
            int offset = 0;
            for (int depth = 31; depth >= 0; depth--)
            {
                try
                {
                    if ((dboptions & GEOIP_MEMORY_CACHE) == 1)
                    {
                        for (int i = 0; i < (2 * MAX_RECORD_LENGTH); i++)
                        {
                            buf[i] = dbbuffer[i + (2 * recordLength * offset)];
                        }
                    }
                    else
                    {
                        lock (ioLock)
                        {
                            file.Seek(2 * recordLength * offset, SeekOrigin.Begin);
                            file.Read(buf, 0, 2 * MAX_RECORD_LENGTH);
                        }
                    }
                }
                catch (IOException)
                {
                    Console.Write("IO Exception");
                }
                for (int i = 0; i < 2; i++)
                {
                    x[i] = 0;
                    for (int j = 0; j < recordLength; j++)
                    {
                        int y = buf[(i * recordLength) + j];
                        if (y < 0)
                        {
                            y += 256;
                        }
                        x[i] += (y << (j * 8));
                    }
                }

                if ((ipAddress & (1 << depth)) > 0)
                {
                    if (x[1] >= databaseSegments[0])
                    {
                        return x[1];
                    }
                    offset = x[1];
                }
                else
                {
                    if (x[0] >= databaseSegments[0])
                    {
                        return x[0];
                    }
                    offset = x[0];
                }
            }

            // shouldn't reach here
            Console.Write("Error Seeking country while Seeking " + ipAddress);
            return 0;

        }
        private static long swapbytes(long ipAddress)
        {
            return (((ipAddress >> 0) & 255) << 24) | (((ipAddress >> 8) & 255) << 16)
          | (((ipAddress >> 16) & 255) << 8) | (((ipAddress >> 24) & 255) << 0);
        }
        private static long bytestoLong(byte[] address)
        {
            long ipnum = 0;
            for (int i = 0; i < 4; ++i)
            {
                long y = address[i];
                if (y < 0)
                {
                    y += 256;
                }
                ipnum += y << ((3 - i) * 8);
            }
            return ipnum;
        }
        private static int unsignedByteToInt(byte b)
        {
            return (int)b & 0xFF;
        }

    }

}