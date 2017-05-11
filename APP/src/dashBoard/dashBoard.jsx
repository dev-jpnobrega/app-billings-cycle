import React, { Component } from 'react'
import {connect} from 'react-redux'
import { bindActionCreators } from 'redux'

import getSummary from './dashboardAction'
import ContentHeader from '../common/template/contentHeader'
import Content from '../common/template/content'
import ValueBox from '../common/widget/valuebox'
import Rows from '../common/layout/row'

class DashBoard extends Component {
    
    componentWillMount() {
        this.props.getSummary();
    }

    render() {
        const { credit, debit } = this.props.summary

        return (   
            <div>
                <ContentHeader title="DashBoard" subTitle="Sub titulo"></ContentHeader>
                <Content> 
                    <Rows>
                        <ValueBox cols='12 4' 
                            color='green' icon='bank' 
                            value={'R$' + credit} text='Total de Créditos' />
                 
                        <ValueBox cols='12 4' 
                                color='red' icon='credit-card' 
                                value={'R$' + debit} text='Total de Débitos' />
                        
                        <ValueBox cols='12 4' 
                                color='blue' icon='money' 
                                value={'R$' + (credit-debit)} text='Valor Consolidado' />
                    </Rows>
                </Content>
            </div>
        )
    }
}

const mapStateToProps = state => ({
    summary: state.dashboard.summary
})

const mapaDispatchToProps = dispatch => 
    bindActionCreators({getSummary}, dispatch)

export default connect(mapStateToProps, mapaDispatchToProps)(DashBoard)
