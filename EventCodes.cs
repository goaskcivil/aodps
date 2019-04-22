﻿using System;


	public enum EventCodes : short
	{
		Leave = 1,
		JoinFinished = 2,
		Move,
		Teleport,
		ChangeEquipment,
		HealthUpdate =6,
		EnergyUpdate,
		DamageShieldUpdate,
		CraftingFocusUpdate,
		ActiveSpellEffectsUpdate,
		ResetCooldowns,
		Attack,
		CastStart,
		CastCancel,
		CastTimeUpdate,
		CastFinished,
		CastSpell,
		CastHit,
		CastHits,
		ChannelingEnded,
		AttackBuilding,
		InventoryPutItem,
		InventoryDeleteItem,
		NewCharacter = 24,
		NewEquipmentItem,
		NewSimpleItem,
		NewFurnitureItem,
		NewJournalItem,
		NewSimpleHarvestableObject,
		NewSimpleHarvestableObjectList,
		NewHarvestableObject,
		NewSilverObject,
		NewBuilding,
		HarvestableChangeState,
		MobChangeState,
		FactionBuildingInfo,
		CraftBuildingInfo,
		RepairBuildingInfo,
		MeldBuildingInfo,
		ConstructionSiteInfo,
		PlayerBuildingInfo,
		FarmBuildingInfo,
		TutorialBuildingInfo,
		LaborerObjectInfo,
		LaborerObjectJobInfo,
		MarketPlaceBuildingInfo,
		HarvestStart,
		HarvestCancel,
		HarvestFinished,
		TakeSilver,
		ActionOnBuildingStart,
		ActionOnBuildingCancel,
		ActionOnBuildingFinished,
		ItemRerollQualityStart,
		ItemRerollQualityCancel,
		ItemRerollQualityFinished,
		InstallResourceStart,
		InstallResourceCancel,
		InstallResourceFinished,
		CraftItemFinished,
		LogoutCancel,
		ChatMessage,
		ChatSay,
		ChatWhisper,
		ChatMuted,
		PlayEmote,
		StopEmote,
		SystemMessage,
		UtilityTextMessage,
		UpdateMoney = 70,
		UpdateFame = 71,
		UpdateLearningPoints,
		UpdateReSpecPoints,
		UpdateCurrency,
		UpdateFactionStanding,
		Respawn,
		ServerDebugLog,
		CharacterEquipmentChanged,
		RegenerationHealthChanged,
		RegenerationEnergyChanged,
		RegenerationMountHealthChanged,
		RegenerationCraftingChanged = 82,
		RegenerationHealthEnergyComboChanged,
		RegenerationPlayerComboChanged,
		DurabilityChanged,
		NewLoot,
		AttachItemContainer,
		DetachItemContainer,
		GuildVaultInfo,
		GuildUpdate,
		GuildPlayerUpdated,
		InvitedToGuild,
		GuildMemberWorldUpdate,
		UpdateMatchDetails,
		ObjectEvent,
		NewMonolithObject,
		NewSiegeCampObject,
		NewOrbObject,
		NewCastleObject,
		NewSpellEffectArea,
		NewChainSpell,
		UpdateChainSpell,
		NewTreasureChest,
		StartMatch,
		StartTerritoryMatchInfos,
		StartArenaMatchInfos,
		EndTerritoryMatch,
		EndArenaMatch,
		MatchUpdate,
		ActiveMatchUpdate,
		NewMob,
		DebugAggroInfo,
		DebugVariablesInfo,
		DebugReputationInfo,
		DebugDiminishingReturnInfo,
		ClaimOrbStart,
		ClaimOrbFinished,
		ClaimOrbCancel,
		OrbUpdate,
		OrbClaimed,
		NewWarCampObject,
		NewMatchLootChestObject,
		NewArenaExit,
		GuildMemberTerritoryUpdate,
		InvitedMercenaryToMatch,
		ClusterInfoUpdate,
		ForcedMovement,
		ForcedMovementCancel,
		CharacterStats,
		CharacterStatsKillHistory,
		CharacterStatsDeathHistory,
		GuildStats,
		KillHistoryDetails,
		FullAchievementInfo,
		FinishedAchievement,
		AchievementProgressInfo,
		FullAchievementProgressInfo = 137,
		FullTrackedAchievementInfo,
		FullAutoLearnAchievementInfo,
		QuestGiverQuestOffered,
		QuestGiverDebugInfo,
		ConsoleEvent,
		TimeSync,
		ChangeAvatar,
		GameEvent,
		KilledPlayer,
		Died,
		KnockedDown,
		MatchPlayerJoinedEvent,
		MatchPlayerStatsEvent,
		MatchPlayerStatsCompleteEvent,
		MatchTimeLineEventEvent,
		MatchPlayerMainGearStatsEvent,
		MatchPlayerChangedAvatarEvent,
		InvitationPlayerTrade,
		PlayerTradeStart,
		PlayerTradeCancel,
		PlayerTradeUpdate,
		PlayerTradeFinished,
		PlayerTradeAcceptChange,
		MiniMapPing,
		MarketPlaceNotification,
		DuellingChallengePlayer,
		NewDuellingPost,
		DuelStarted,
		DuelEnded,
		DuelDenied,
		DuelLeftArea,
		DuelReEnteredArea,
		NewRealEstate,
		MiniMapOwnedBuildingsPositions,
		RealEstateListUpdate,
		GuildLogoUpdate,
		GuildLogoChanged,
		PlaceableItemPlace,
		PlaceableItemPlaceCancel,
		FurnitureObjectBuffProviderInfo,
		FurnitureObjectCheatProviderInfo,
		FarmableObjectInfo,
		LaborerObjectPlace,
		LaborerObjectPlaceCancel,
		NewUnreadMails,
		GuildLogoObjectUpdate,
		StartLogout,
		NewChatChannels,
		JoinedChatChannel,
		LeftChatChannel,
		RemovedChatChannel,
		AccessStatus,
		Mounted,
		MountCancel,
		NewTravelpoint,
		NewIslandAccessPoint,
		NewExit,
		UpdateHome,
		UpdateChatSettings,
		ResurrectionOffer,
		ResurrectionReply,
		LootEquipmentChanged,
		UpdateUnlockedGuildLogos,
		UpdateUnlockedAvatars,
		UpdateUnlockedAvatarRings,
		UpdateUnlockedBuildings,
		DailyLoginBonus,
		NewIslandManagement,
		NewTeleportStone,
		Cloak,
		PartyInvitation = 208,
		PartyJoined = 209,
		PartyDisbanded,
		PartyPlayerJoined =221,
		PartyChangedOrder,
		PartyPlayerLeft,
		PartyLeaderChanged,
		PartyLootSettingChangedPlayer,
		PartySilverGained,
		PartyPlayerUpdated = 227,
		PartyInvitationPlayerBusy,
		PartyMarkedObjectsUpdated,
		PartyOnClusterPartyJoined,
		PartySetRoleFlag,
		SpellCooldownUpdate,
		NewHellgate,
		NewHellgateExit,
		NewExpeditionExit,
		NewExpeditionNarrator,
		ExitEnterStart,
		ExitEnterCancel,
		ExitEnterFinished,
		HellClusterTimeUpdate,
		NewQuestGiverObject,
		FullQuestInfo = 232,
		QuestProgressInfo,
		QuestGiverInfoForPlayer,
		FullExpeditionInfo,
		ExpeditionQuestProgressInfo,
		InvitedToExpedition,
		ExpeditionRegistrationInfo,
		EnteringExpeditionStart,
		EnteringExpeditionCancel,
		RewardGranted,
		ArenaRegistrationInfo,
		EnteringArenaStart,
		EnteringArenaCancel,
		EnteringArenaLockStart,
		EnteringArenaLockCancel,
		InvitedToArenaMatch,
		PlayerCounts,
		InCombatStateUpdate,
		OtherGrabbedLoot,
		SiegeCampClaimStart,
		SiegeCampClaimCancel,
		SiegeCampClaimFinished,
		SiegeCampScheduleResult,
		TreasureChestUsingStart,
		TreasureChestUsingFinished,
		TreasureChestUsingCancel,
		TreasureChestUsingOpeningComplete,
		TreasureChestForceCloseInventory,
		PremiumChanged,
		PremiumExtended,
		PremiumLifeTimeRewardGained,
		LaborerGotUpgraded,
		JournalGotFull,
		JournalFillError,
		FriendRequest,
		FriendRequestInfos,
		FriendInfos,
		FriendRequestAnswered,
		FriendOnlineStatus,
		FriendRequestCanceled,
		FriendRemoved,
		FriendUpdated,
		PartyLootItems,
		PartyLootItemsRemoved,
		ReputationUpdate,
		DefenseUnitAttackBegin,
		DefenseUnitAttackEnd,
		DefenseUnitAttackDamage,
		UnrestrictedPvpZoneUpdate,
		ReputationImplicationUpdate,
		NewMountObject,
		MountHealthUpdate,
		MountCooldownUpdate,
		NewExpeditionAgent,
		NewExpeditionCheckPoint,
		ExpeditionStartEvent,
		VoteEvent,
		RatingEvent,
		NewArenaAgent,
		BoostFarmable,
		UseFunction,
		NewPortalEntrance,
		NewPortalExit,
		NewRandomDungeonExit,
		WaitingQueueUpdate,
		PlayerMovementRateUpdate,
		ObserveStart,
		MinimapZergs,
		PaymentTransactions,
		PerformanceStatsUpdate,
		OverloadModeUpdate,
		DebugDrawEvent,
		RecordCameraMove,
		RecordStart,
		TerritoryClaimStart,
		TerritoryClaimCancel,
		TerritoryClaimFinished,
		TerritoryScheduleResult,
		UpdateAccountState,
		StartDeterministicRoam,
		GuildFullAccessTagsUpdated,
		GuildAccessTagUpdated,
		GvgSeasonUpdate,
		GvgSeasonCheatCommand,
		SeasonPointsByKillingBooster,
		FishingStart,
		FishingCast,
		FishingCatch,
		FishingFinished,
		FishingCancel,
		NewFloatObject,
		NewFishingZoneObject,
		FishingMiniGame,
		SteamAchievementCompleted,
		UpdatePuppet,
		ChangeFlaggingFinished,
		NewOutpostObject,
		OutpostUpdate,
		OutpostClaimed,
		OutpostReward,
		OverChargeEnd,
		OverChargeStatus,
		PartyFinderFullUpdate,
		PartyFinderUpdate,
		PartyFinderApplicantsUpdate,
		PartyFinderEquipmentSnapshot,
		PartyFinderJoinRequestDeclined,
		NewUnlockedPersonalSeasonRewards,
		PersonalSeasonPointsGained,
		EasyAntiCheatMessageToClient,
		MatchLootChestOpeningStart,
		MatchLootChestOpeningFinished,
		MatchLootChestOpeningCancel,
		NotifyCrystalMatchReward,
		CrystalRealmFeedback,
		NewLocationMarker,
		NewTutorialBlocker,
		NewInformationProvider,
		NewDynamicGuildLogo,
		TutorialUpdate,
		TriggerHintBox,
		RandomDungeonPositionInfo,
		NewLootChest,
		UpdateLootChest,
		LootChestOpened,
		NewShrine,
		UpdateShrine,
		MutePlayerUpdate,
		ShopTileUpdate,
		ShopUpdate,
		EasyAntiCheatKick
	}
