﻿
// Enum con las escenas del juego IMPORTANTE "Match" de nombre
public enum gameScenes {
    dialog, game1, game2, game3, game4
}

// Enum "básico" para determinar el estado de algo
public enum state {
    Active, Inactive
}

// Enum para la seguridad de la FStateMachine
public enum fsmSecurity {
    None, Soft, Hard
}

// Enum que determina el tipo de audio que vamos a reproducir
public enum audioType {
    SFX_3D, SFX_2D, SoundTrack
}

// Enum que determina el timpo de Input D: (algo más "homemade")
public enum inputScheme {
    Keyboard, Mouse, GamePad
}

// Enum para indicar los idiomas que tiene le juego en temas de Localización
public enum language {
    EN
}

// Enum para los diferentes efectos disponibles
public enum effects {
    fadeIn, fadeOut, cameraShake
}

// Enum para indicar el progresso de algo
public enum progress {
    ready, doing, done
}