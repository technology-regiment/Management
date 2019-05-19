import { Component } from 'react';
import { connect } from 'dva';
import {  Input,Col,Row ,Layout} from 'antd';
import Users from './components/Users';
const { Content } = Layout;

const { Search } = Input
class Userdashboard extends Component {
  state = {
    filter: {},
    pagination: {
      orderProperty: 'Name',
      ascending: false,
      pageNumber: 1,
      pageSize: 10,
    },
  };

  getByPage = () => {
    const { filter, pagination } = this.state;
    this.props.dispatch({
      type: 'user-dashboard/fetch',
      payload: {
        filter,
        ...pagination,
      },
    });
  };

  queryByPage = (value)=>{
    const {pagination} =this.state;
    const filter={'Name':value}
    this.props.dispatch(
      {
        type: 'user-dashboard/fetch',
        payload: {
          filter,
          ...pagination,
        },
      }
    );
  }
  componentDidMount() {
    this.getByPage();
  }

  render() {
    return (
      <Content
      style={{
        margin: '24px 16px 0',
        padding: 24,
        background: '#fff',
        minHeight: '670px',
      }}>
      <div>
        <div>
          <Row >
            <Col span={4}>
              <Search
                onSearch={this.queryByPage}
              />
            </Col>
          </Row>
        </div>
      <div>
        <Users />
      </div>
    </div>
      </Content>


    );
  }
}

export default connect()(Userdashboard);
