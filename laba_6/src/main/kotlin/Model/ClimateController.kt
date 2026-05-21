package Model

class ClimateController(
    private val thermostat: ThermostatService,
    private val alerts: AlertSystem
) {
    fun onTimerTick() {
        try { thermostat.regulateClimate() } catch (e: Exception) { alerts.signalDanger() }
    }
}