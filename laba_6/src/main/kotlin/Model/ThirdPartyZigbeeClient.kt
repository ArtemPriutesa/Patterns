package Model

class ThirdPartyZigbeeClient {
    fun sendCommand(id: String, cmd: String) = println("[HW] $id -> $cmd")
}