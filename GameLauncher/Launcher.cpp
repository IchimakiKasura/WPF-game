#include <iostream>
#include <fstream>
#include <filesystem>
#include <Windows.h>
#include <stdlib.h>

void deletes()
{
    system("attrib -s -h Game.bin.config");
    system("del Game.bin.config");
}

int APIENTRY WinMain(HINSTANCE hInst, HINSTANCE hInstPrev, PSTR cmdline, int cmdshow)
{
    std::ofstream AppConfig("Game.bin.config");

    AppConfig << "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n"
    "<configuration>\n" 
    "<runtime>\n"
    "    <assemblyBinding xmlns=\"urn:schemas-microsoft-com:asm.v1\">\n"
    "    <probing privatePath=\"Game;Game/bin\"/>\n"
    "    </assemblyBinding>\n"
    "</runtime>\n"
    "<startup>\n"
    "    <supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.8\" />\n"
    "</startup>\n"
    "</configuration>";

    AppConfig.close();

    system("attrib +s +h Game.bin.config");

    bool IsExist = std::filesystem::exists("Game.bin");

    if (IsExist)
    {
        system("start Game.bin");
        Sleep(1000);
        deletes();
    }
    else
    {
        MessageBox(NULL, "Game.bin is missing!", "ERROR", 0);
        deletes();
    }


    return NULL, NULL, NULL, 0;
}