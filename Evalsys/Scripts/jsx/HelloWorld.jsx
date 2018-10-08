var HelloWorld = React.createClass({

    getInitialState: function () {
        return { courses: [] };
    },

    componentDidMount: function () {
        $.ajax({
            url: this.props.url,
            dataType: 'json',
            success: function (data) {
                this.setState(data);
            }.bind(this),
            error: function (xhr, status, err) {
                console.error(this.props.url, status, err.toString());
            }.bind(this)
        });
    },

    render: function () {
        return (
            <div> Courses: <ul> {this.state.courses && this.state.courses.map((course, index) => this.renderCourses(course, index))} </ul></div>
        );
    },

    renderCourses: function (course, index) {
        return (<li key={index}>{course.course_name}</li>)
    }
});

React.render(
    <HelloWorld url="/home/getcourses" />,
    document.getElementById('container')
);