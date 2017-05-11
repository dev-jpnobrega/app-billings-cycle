const express = require('express')

module.exports = server => {
    //Definir a url base para todas as router
    const router = express.Router()
    server.use('/api', router)

    //Rotas do Clico de Pagamento
    const BillingCycle = require('../api/billingCycle/billingCycleService')

    BillingCycle.register(router, '/billingCycles')
}
