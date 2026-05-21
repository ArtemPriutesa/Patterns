package Model

class SensorRepository(private val cache: RedisCache) {
    fun getCurrentTemperature() = cache.getLatestValue("room_temp")
}