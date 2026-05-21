package Model

class ThermostatService(
    private val sensors: SensorRepository,
    private val devices: DeviceManager,
    private val config: UserPreferencesProvider
) {
    fun regulateClimate() {
        val current = sensors.getCurrentTemperature()
        val target = config.getTargetTemperature()
        if (current < target) devices.toggleHeater(true) else devices.toggleHeater(false)
    }
}