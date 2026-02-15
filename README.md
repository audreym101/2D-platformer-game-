

## Issues Fixed

### 1. ✅ Player Dies in Water
**Solution**: Updated `WaterTrigger.cs` to call `PlayerDamage.DealDamage()` when player enters water
- Water now uses the same damage system as enemies
- Consistent behavior across all death scenarios

### 2. ✅ Player Can Jump to Collect Coins
**Solution**: Already implemented in `PlayerMovement.cs`
- Spacebar triggers jump when player is grounded
- Jump power is set to 12f (adjustable in inspector)
- Works perfectly for collecting coins above platforms

### 3. ✅ Respawn Few Steps Back from Death
**Solution**: Updated `GameManager.cs` respawn logic
- Player respawns 3 units back (X-axis) from death position
- Player respawns 2 units up (Y-axis) to avoid immediate re-trigger
- Works for both water deaths and enemy deaths
- Velocity is reset to prevent momentum issues

## How It Works

### Death Flow:
1. Player touches enemy OR enters water
2. `PlayerDamage.DealDamage()` is called
3. Life count decreases
4. If lives > 0: `GameManager.PlayerDied()` is called with death position
5. Player respawns at: `(deathX - 3, deathY + 2, deathZ)`
6. If lives = 0: Game Over scene loads

### Jump Flow:
1. Player presses spacebar
2. `CheckIfGrounded()` confirms player is on ground
3. `PlayerJump()` applies upward velocity (12f)
4. Player can collect coins while in air

## Files Modified

1. **GameManager.cs**
   - Changed respawn offset to 3 units back on X-axis
   - Added coroutine for smooth respawn
   - Removed DontDestroyOnLoad (not needed for single scene)

2. **PlayerDamage.cs**
   - Integrated with GameManager for respawn
   - Calls `GameManager.PlayerDied()` when lives > 0
   - Calls `GameManager.GameOver()` when lives = 0

3. **WaterTrigger.cs**
   - Now calls `PlayerDamage.DealDamage()` instead of direct GameManager call
   - Unified with enemy damage system

## Testing Instructions

1. **Test Jump for Coins**:
   - Run game
   - Press spacebar to jump
   - Verify player can reach and collect coins above platforms

2. **Test Enemy Death**:
   - Let enemy touch player
   - Verify life decreases
   - Verify player respawns 3 steps back from death position

3. **Test Water Death**:
   - Jump into water
   - Verify life decreases
   - Verify player respawns 3 steps back from water position

4. **Test Game Over**:
   - Die 3 times (lose all lives)
   - Verify End Scene loads with Replay and Quit buttons

## Configuration

You can adjust these values in the scripts:

- **Jump Power**: Line 18 in `PlayerMovement.cs` → `jumpPower = 12f`
- **Respawn Offset X**: Line 12 in `GameManager.cs` → `respawnOffsetX = 3f`
- **Respawn Offset Y**: Line 38 in `GameManager.cs` → `deathPosition.y + 2f`
- **Starting Lives**: Line 12 in `PlayerDamage.cs` → `lifeScoreCount = 3`
