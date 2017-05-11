const _ = require('lodash')

const parseErrors = (nodeErrors) => {
    const errors = []
    _.forIn(nodeErrors, error => errors.push(error.message))

    return errors;
}


module.exports = (req, resp, next) => {
    const bundle = resp.locals.bundle
    if (bundle.errors) {
        const errors = parseErrors(bundle.errors)
        resp.status(500).json({errors})
    } else {
        next()
    }
}