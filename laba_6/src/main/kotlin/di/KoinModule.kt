package di

import Model.AlertSystem
import Model.ClimateController
import Model.DeviceManager
import Model.RedisCache
import Model.SensorRepository
import Model.ThermostatService
import Model.ThirdPartyZigbeeClient
import Model.UserPreferencesProvider
import org.koin.dsl.module


val climateModule = module {
    single { RedisCache() }
    single { ThirdPartyZigbeeClient() }

    factory { SensorRepository(get()) }
    factory { DeviceManager(get()) }

    factory { UserPreferencesProvider() }
    factory { ThermostatService(get(), get(), get()) }

    factory { AlertSystem() }
    factory { ClimateController(get(), get()) }
}