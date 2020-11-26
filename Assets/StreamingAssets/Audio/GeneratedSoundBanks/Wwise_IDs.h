/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID ARROWSHOT = 845452308U;
        static const AkUniqueID BROKENFLOOR = 2665995544U;
        static const AkUniqueID CLOCKIN = 3732233112U;
        static const AkUniqueID CLOCKOUT = 3250926143U;
        static const AkUniqueID DASHAVAILABLE = 2598305070U;
        static const AkUniqueID DASHIN = 500575488U;
        static const AkUniqueID DASHJUMP = 2902735605U;
        static const AkUniqueID DEADBYARROWS = 2119947522U;
        static const AkUniqueID DEADBYFALL = 3380611355U;
        static const AkUniqueID DEADBYFISH = 3731661478U;
        static const AkUniqueID DEADBYPINCHES = 1874851080U;
        static const AkUniqueID DEADBYSHADOW = 3511500052U;
        static const AkUniqueID DEADMENU = 1118120938U;
        static const AkUniqueID DESAGUE = 2020903617U;
        static const AkUniqueID FISHJUMP = 1578009071U;
        static const AkUniqueID GAMESTART = 4058101365U;
        static const AkUniqueID MATCHSTART = 4152065628U;
        static const AkUniqueID MENUSTART = 1447920996U;
        static const AkUniqueID MOUSECLICK = 4010314750U;
        static const AkUniqueID NEW_EVENT = 3050945240U;
        static const AkUniqueID PAUSEIN = 181417420U;
        static const AkUniqueID PAUSEOUT = 3635785963U;
        static const AkUniqueID PLAYFOOTSTEP = 1712852617U;
        static const AkUniqueID SCORE0 = 2283883555U;
        static const AkUniqueID SCORE100 = 2285156786U;
        static const AkUniqueID SCORE250 = 87141506U;
        static const AkUniqueID SCORE400 = 104904959U;
        static const AkUniqueID SHADOW = 3140781661U;
        static const AkUniqueID SLIPPERYFLOOR = 2952340197U;
        static const AkUniqueID SPAWNWISPS = 280766994U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace GAME_MODES
        {
            static const AkUniqueID GROUP = 2891432982U;

            namespace STATE
            {
                static const AkUniqueID CLOCK_IN = 2907590929U;
                static const AkUniqueID GAME_START = 733168346U;
                static const AkUniqueID IN_DEAD_MENU = 4063988593U;
                static const AkUniqueID IN_MATCH = 1686036574U;
                static const AkUniqueID IN_MENU = 1631528850U;
                static const AkUniqueID IN_PAUSE = 2182592203U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace GAME_MODES

        namespace SCORES
        {
            static const AkUniqueID GROUP = 2283883616U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID SCORE0 = 2283883555U;
                static const AkUniqueID SCORE100 = 2285156786U;
                static const AkUniqueID SCORE250 = 87141506U;
                static const AkUniqueID SCORE400 = 104904959U;
            } // namespace STATE
        } // namespace SCORES

    } // namespace STATES

    namespace SWITCHES
    {
        namespace DEADBY
        {
            static const AkUniqueID GROUP = 3119544328U;

            namespace SWITCH
            {
                static const AkUniqueID ARROWS = 1257608559U;
                static const AkUniqueID FALL = 2512384458U;
                static const AkUniqueID FISH = 2695658327U;
                static const AkUniqueID PINCHES = 548708371U;
                static const AkUniqueID SHADOW = 3140781661U;
            } // namespace SWITCH
        } // namespace DEADBY

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID MUSICVOLUME = 2346531308U;
        static const AkUniqueID SFXVOLUME = 988953028U;
        static const AkUniqueID SHADOWDISTANCE = 915746400U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSICA = 1730564739U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
