package Model

class DeviceManager(private val gateway: ThirdPartyZigbeeClient) {
    fun toggleHeater(on: Boolean) = gateway.sendCommand("heater_01", if(on) "ON" else "OFF")
}