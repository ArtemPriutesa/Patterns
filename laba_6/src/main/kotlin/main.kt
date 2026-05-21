import Model.AlertSystem
import Model.ClimateController
import di.climateModule
import org.koin.core.context.startKoin

fun main(){
    val koinApp = startKoin {
        printLogger()
        modules(climateModule)
    }

    val controller = koinApp.koin.get<ClimateController>()

    controller.onTimerTick()
}