import { Component } from 'react';
import { connect } from 'dva';
import Users from './components/Users';

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
  componentDidMount() {
    this.getByPage();
  }

  render() {
    return (
      <div>
        <Users />
      </div>
    );
  }
}

export default connect()(Userdashboard);
